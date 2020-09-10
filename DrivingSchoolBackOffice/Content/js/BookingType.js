var BookingTypeViewModel = function () {
    // Make self as reference
    self = this;

    //observable variables that will be used for binding with the UI
    self.BookingTypeId = ko.observable("");
    self.BktName = ko.observable("");

    var BookingTypeData = {
        BookingTypeId=self.BookingTypeId,
        BktName=self.BktName,
        ShortDescription=sel.ShortDescription
    };


    //Array to store the json results from the API
    self.BookingTypes = ko.observableArray([]);
    self.rootUrl = "https://localhost:44347/api/BookingTypes";
    GetBookingTypes();
    self.save = function () {
        //Ajax call to save record
        $.ajax({
            type: "POST",
            url: self.rootUrl,
            data: ko.toJSON(BookingTypeData),
            success: function (data) {
                alert("Record Added Successfully");
                self.StudentId(data.BookingTypeId);
                alert("The New BookingType Id :" + self.BookingTypeId());
                GetBookingTypes();
            },
            error: function () {
                alert("Failed");
            }
        });
        // Ends Here
    }

    self.update = function () {
        $.ajax({
            type: "PUT",
            url: self.rootUrl + "?bookingTypeId=" + self.BookingTypeId(),
            data: ko.toJSON(BookingTypeData),
            contentType: "application/json",
            success: function (data) {
                alert("Record Updated Successfully");
                GetBookingTypes();
            }
        });
    }

    self.delete = function () {
        $.ajax({
            type: "DELETE",
            url: self.rootUrl + "?bookingTypeId=" + self.BookingTypeId,
            data: ko.toJSON(BookingTypeData),
            success: function (data) {
                alert("Record Deleted successfully");
                GetBookingTypes();
            },
            error: function (error) {
                alert("An error occured while trying to precess your request");
            }
        });
    }

    function GetBookingTypes() {
        $.ajax({
            type: "GET",
            url: sel.rootUrl,
            contentType: "json",
            success: function (data) {
                self.BookingTypeData(data);
            }
        });
    }

    self.getSelectedBookingType = function (data) {
        self.BookingTypeId(data.BookingTypeId);
        self.BktName(data.BktName);
        self.ShortDescription(data.ShortDescription)
    };
}
ko.applyBindings(new BookingTypeViewModel());  