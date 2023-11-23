$(document).ready(function () {

    $.fn.serializeObject = function () {
        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name]) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };

    var UserRecords = $('#UserList').DataTable({
        "lengthChange": false,
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": "https://localhost:7057/api/User/list",
            "type": "GET",
            dataSrc: ''
        },
        columns: [
            { data: 'id' },
            { data: 'name' },
            { data: 'number' },
            { data: 'add' },
            { data: 'email' },
            {
                'data': null, title: 'Action', "render": function (data, type, row, meta) {
                    return `<div class="btn-group" id="${row.id}"> 
                    <button type="button" class="btn btn-light edit" id="${row.id}-edit"  >Edit
                    </button> <button type="button" class="btn btn-danger delete"
                    id="${row.id}-delete" >Delete</button></div>`
                }
            },

        ],
        "pageLength": 10,

    });

    $('#addUser').click(function () {
        $('#UserModal').modal('show');
        $('#UserForm')[0].reset();
        $('.modal-title').html("<i class='fa fa-plus'></i> Add User");
        $('#action').val('addUser');
        $('#save').val('Add');
    });

    function onEdit(row) {
        var id = row.id;
        $.ajax({
            url: "https://localhost:7057/api/User/" + id,
            method: "GET",
            dataType: "json",
            success: function (data) {
                $('#UserModal').modal('show');
                $('#id').val(data.id);
                $('#UserName').val(data.name);
                $('#number').val(data.number);
                $('#address').val(data.add);
                $('#UserEmail').val(data.add);
                

                $('.modal-title').html("<i class='fa fa-edit'></i> Edit User");
                $('#action').val('updateUser');
                $('#save').val('Save');
            }
        })
    }

    $("#UserModal").on('submit', '#UserForm', function (event) {
        event.preventDefault();
        $('#save').attr('disabled', 'disabled');
        var formData = $(this).serializeObject();
        if (!formData.id) {
            $.ajax({
                url: "https://localhost:7057/api/User",
                method: "POST",
                contentType: 'application/json',
                data: JSON.stringify(formData),
                dataType: 'json',
                success: function (data) {
                    $('#UserForm')[0].reset();
                    $('#UserModal').modal('hide');
                    $('#save').attr('disabled', false);
                    UserRecords.ajax.reload();
                }
            })
        } else {
            $.ajax({
                url: "https://localhost:7057/api/User/" + formData.id,
                method: "PUT",
                contentType: 'application/json',
                data: JSON.stringify(formData),
                dataType: 'json',
                success: function (data) {
                    $('#UserForm')[0].reset();
                    $('#UserModal').modal('hide');
                    $('#save').attr('disabled', false);
                    UserRecords.ajax.reload();
                }
            })
        }

    });

    function onDelete(row) {
        var id = row.id;
        if (confirm("Are you sure you want to delete this User?")) {
            $.ajax({
                url: "https://localhost:7057/api/User/" + id,
                method: "DELETE",
                success: function (data) {
                    UserRecords.ajax.reload();
                }
            })
        } else {
            return false;
        }
    }

    $('#UserList tbody').on('click', '.edit', function () {
        var tr = $(this).closest('tr');
        var data = UserRecords.row(tr).data();
        onEdit(data);
    });


    $('#UserList tbody').on('click', '.delete', function () {
        var tr = $(this).closest('tr');
        var data = UserRecords.row(tr).data();
        onDelete(data);

    });



});