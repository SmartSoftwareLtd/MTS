




// To set dropdown index by value
function setSelectedIndexByValue(s, valsearch) {
    debugger
    // Loop through all the items in drop down list

    for (i = 0; i < s.options.length; i++) {

        if (s.options[i].value == valsearch) {

            // Item is found. Set its property and exit

            s.options[i].selected = true;

            break;

        }

    }

    return;

}

//To set dropdown index by text
function setSelectedIndexByText(s, textToFind) {

    // Loop through all the items in drop down list

    for (var i = 0; i < s.options.length; i++) {
        if (s.options[i].text === textToFind) {
            s.selectedIndex = i;
            break;
        }
    }

    return;

}
