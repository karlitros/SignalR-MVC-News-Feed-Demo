/// <reference path="jquery-1.7.2.js" />
/// <reference path="jquery-ui-1.8.20.js" />
/// <reference path="jquery.signalR-0.5.2.js" />

$(function () {
    // Establish a connection to the updateFeed hub
    var hub = $.connection.updateFeed;

    // Extend the object with our feedUpdated method held within the updateFeed hub
    $.extend(hub, {
        feedUpdated: function (data) {
            // Container for newItem
            var blankDiv = $("<div class='itemContainer'></div>");

            // Holds the update
            var newItem = $("<div class='" + data.UpdateType.toLowerCase() + "_item'><span>" + data.Name + "</span></div>");

            // Hide our blank div (that will contain the new update), and our new item itself.
            // The blank div will slide down, and our newItem will fade into existence.
            blankDiv.hide();
            newItem.hide();

            // Insert the update at the top of the list, as it's sorted in descending order by publish date.
            $("div#container div:first").before(blankDiv);
            blankDiv.html(newItem);

            // Slide down the blank div (it has a fixed height in CSS), and then fade the new update in.
            blankDiv.slideDown(500, null, function () {
                newItem.fadeIn(2000)
            });
        }
    });

    // Kick off the connection.
    $.connection.hub.start();
});