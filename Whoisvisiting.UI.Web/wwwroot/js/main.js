$(document).ready(function () {

    $("#contacts-table tbody").on("click", ".edit-contact", function () {
        var contactId = $(this).data('id');
        loadEditModalContent(contactId);
    });

    $("#contacts-table tbody").on("click", ".delete-contact", function () {
        var contactId = $(this).data('id');
        loadDeleteModalContent(contactId);
    });

    $("#newContact").on("click", function (e) {
        loadNewModalContent();
        e.preventDefault();
    });

    function loadDeleteModalContent(id) {
        let deleteUrl = `/Contact/Delete/${id}`;
        GetRequest(deleteUrl, showDeleteModal);
    }

    function loadEditModalContent(id) {
        let editUrl = `/Contact/Edit/${id}`;
        GetRequest(editUrl, showEditModal);
    }

    function loadNewModalContent(id) {
        let createUrl = `/Contact/Create`;
        GetRequest(createUrl, showNewModal);
    }

    function showDeleteModal(content){
        if (content !== 'underfined'){
            
            let deleteModal = $('#deleteContactModal');
            deleteModal.find('.modal-body').html(content);
            deleteModal.modal('show');
        }
    }

    function showEditModal(content){
        if (content !== 'underfined') {

            let editModal = $('#editContactModal');
            editModal.find('.modal-body').html(content);
            editModal.modal('show');

            let form = editModal.find('form');
            addDynamicFormValidation(form);
        }
    }

    function showNewModal(content) {
        if (content !== 'underfined') {

            let newModal = $('#newContactModal');
            newModal.find('.modal-body').html(content);
            newModal.modal('show');

            let form = newModal.find('form');
            addDynamicFormValidation(form);
        }
    }

    function GetRequest(resourcePath, successCallBack) {
        $.get(resourcePath, function () {
        }).done(successCallBack).fail(function () {
            alert("Error loading form, try again");
        });
    }

    function addDynamicFormValidation(newForm) {
        $.validator.unobtrusive.parse(newForm);
    }
});