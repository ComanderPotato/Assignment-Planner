function getElementAtCoordinates(x, y) {
    let element = document.elementFromPoint(x, y);
    console.log(element.getAttribute('data-date'))
    return element.getAttribute('data-date');
}
function hideSidebar() {
    const dashboard = document.querySelector(".dashboard");
    const sidebar = document.querySelector(".sidebar-content")

    dashboard.classList.toggle("dashboard-sidebar--hidden")
    sidebar.classList.toggle("sidebar-hidden");
}