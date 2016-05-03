function Dropdown(dropdownPlaceholder, placeholderText) {
    var $placeholder = $(dropdownPlaceholder);
    $placeholder.append("<span>" + placeholderText + "</span>");

    var $source = $(".custom-dropdown-source");

    // create dropdown placeholder
    var $dropdown = $("<ul class='custom-dropdown'>");
    $dropdown.css({ 'top': $placeholder.position().top + $placeholder.outerHeight() + 'px' }
    //    {
    //    'width': $placeholder.css('width'),
    //    'top': $placeholder.position().top + $placeholder.outerHeight() + 'px',
    //    'left': $placeholder.position().left + 'px'
    //}
    );
    $dropdown.hide();

    // create options
    $source.children().each(function (e) {
        // add options to the dropdown + attach event handler 
    });
    $dropdown.append("<li><span>Test</span></li>");

    $placeholder.append($dropdown);

    this.dropdown = $dropdown;
    var that = this;

    $placeholder.on('click', function (e) {
        if (that.dropdown.is(":visible"))
            that.dropdown.hide();
        else
            that.dropdown.show();
    });
};