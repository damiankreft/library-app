// https://www.worldometers.info/geography/alphabetical-list-of-countries/
var output = "";
for (var i = 1; i < 195; i++) {
    var trChildren = tab.children[1].children[i].getElementsByTagName("td");
    let id = trChildren[0].innerText;
    let nationality = trChildren[1].innerText;
    output += "INSERT INTO Nationality (id, nationality) VALUES(\"" + id + "\", \"" + nationality + "\");";
}