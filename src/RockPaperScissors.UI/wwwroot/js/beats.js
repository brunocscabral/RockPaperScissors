const beat = (type, moveId, beatId) => {
    $.post(`/Move/${type}Beat`, 
        { moveId: moveId, beatId: beatId },
        (data, status) => {
            if (status !== 'success') {
                alert("Error processing request");
                window.location.reload();
            }
        }
    );
}

const addBeat = (moveId, beatId) => beat('Add', moveId, beatId);
const delBeat = (moveId, beatId) => beat('Del', moveId, beatId);

$('input[type=checkbox]').change(function () {
    const moveId = this.id.split("*")[0];
    const beatId = this.id.split("*")[1];

    if ($(this).prop("checked")) {
        addBeat(moveId, beatId)
    } else {
        delBeat(moveId, beatId)
    }
});