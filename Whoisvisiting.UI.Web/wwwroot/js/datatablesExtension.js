$(document).ready(function () {
    $('#contacts-table').DataTable({
        "ajax": '/Contact/Contacts',
        "columns": [
            { "title": "Name", "data": "name" },
            { "title": "Email", "data": "email" },
            { "title": "PhoneNumber", "data": "phoneNumber" },
            { "title": "Domain", "data": "domain" },
            { "title": "Notes", "data": "notes" },
            { "title": "" },
        ],
        "columnDefs": [
            {
                "targets": 0,
                "data": "name",
                "render": function (data, type, row, meta) {
                    return `<a href="/Contact/Details/${row.id}">${data}</a>`;
                }
            },
            {
            "targets": 1,
            "data": "email",
            "render": function (data, type, row, meta) {
                    return `<a href="mailto:' ${data} '?">${data}</a>`;
                }
            },
            {
                "targets": 3,
                "data": "domain",
                "render": function (data, type, row, meta) {
                    return `<a href="${data}" target="_blank">${data} <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" aria-hidden="true" focusable="false" width="1em" height="1em" style="-ms-transform: rotate(360deg); -webkit-transform: rotate(360deg); transform: rotate(360deg);" preserveAspectRatio="xMidYMid meet" viewBox="0 0 24 24"><path d="M18 10.82a1 1 0 0 0-1 1V19a1 1 0 0 1-1 1H5a1 1 0 0 1-1-1V8a1 1 0 0 1 1-1h7.18a1 1 0 0 0 0-2H5a3 3 0 0 0-3 3v11a3 3 0 0 0 3 3h11a3 3 0 0 0 3-3v-7.18a1 1 0 0 0-1-1zm3.92-8.2a1 1 0 0 0-.54-.54A1 1 0 0 0 21 2h-6a1 1 0 0 0 0 2h3.59L8.29 14.29a1 1 0 0 0 0 1.42a1 1 0 0 0 1.42 0L20 5.41V9a1 1 0 0 0 2 0V3a1 1 0 0 0-.08-.38z" fill="#0366d6"/></svg></a>`;
                }
            },
            {
                "targets": 5,
                "data": "id",
                "searchable": false,
                "orderable": false,
                "render": function (data, type, row, meta) {
                    return `<div><button data-id="${data}" type="button" class="btn btn-link edit-contact">Edit</button>
                                     <button data-id="${data}" type="button" class="btn btn-link delete-contact">Delete</button></div>`;
                }
            }
        ]
    });
});