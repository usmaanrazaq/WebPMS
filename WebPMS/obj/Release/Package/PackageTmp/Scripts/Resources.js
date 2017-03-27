function InitalizejQuery() {
    $('.draggable').draggable({
        helper: 'clone',
        start: function (ev, ui) {
            var $draggingElement = $(ui.helper);
            $draggingElement.width(gridView.GetWidth());
        }
    });
    $('.draggable').droppable({
        activeClass: "hover",
        tolerance: "intersect",
        hoverClass: "activeHover",
        drop: function (event, ui) {
            var draggingSortIndex = ui.draggable.attr("displayIndex");
            var targetSortIndex = $(this).attr("displayIndex");
            gridView.PerformCallback(
                {
                    draggingIndex: draggingSortIndex,
                    targetIndex: targetSortIndex,
                    command: "DRAGROW"
                });
        }
    });
}
function UpdatedGridViewButtonsState(grid) {
    btMoveUp.SetEnabled(grid.cpbtMoveUp_Enabled);
    btMoveDown.SetEnabled(grid.cpbtMoveDown_Enabled);
}

function gridView_Init(s, e) {
    UpdatedGridViewButtonsState(s);
}

function gridView_EndCallback(s, e) {
    UpdatedGridViewButtonsState(s);
    s.AdjustControl();
}

function btMoveUp_Click(s, e) {
    gridView.PerformCallback(
        {
            focusedRowIndex: gridView.GetFocusedRowIndex(),
            command: "MOVEUP"
        });
}

function btMoveDown_Click(s, e) {
    gridView.PerformCallback(
        {
            focusedRowIndex: gridView.GetFocusedRowIndex(),
            command: "MOVEDOWN"
        });
}
