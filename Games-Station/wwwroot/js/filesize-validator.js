// Add the custom validation method
$.validator.addMethod('filesize', function (value, element, param) {
    if (element.files && element.files[0]) {
        return this.optional(element) || element.files[0].size <= param;
    }
    return true; // Validate as true if there is no file
}, 'File size must be less than or equal to {0} bytes.');

// Initialize form validation
$(document).ready(function () {
    $('#myForm').validate({
        rules: {
            fileInput: {
                filesize: 1048576 // 1 MB in bytes
            }
        },
        messages: {
            fileInput: {
                filesize: 'Maximum allowed size is 1 MB'
            }
        }
    });
});
