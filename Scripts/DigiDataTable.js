$(document).ready(function () {
    $('#dt-basic-example thead tr').clone(true).appendTo('#dt-basic-example thead');
    $('#dt-basic-example thead tr:eq(1) th').each(function (i) {
        var title = $(this).text();
        $(this).html('<input type="text" class="form-control form-control-sm" placeholder="Search ' + title + '" />');

        $('input', this).on('keyup change', function () {
            if (table.column(i).search() !== this.value) {
                table
                    .column(i)
                    .search(this.value)
                    .draw();
            }
        });
    });
    var table = $('#dt-basic-example').DataTable({
        responsive: true,
        orderCellsTop: true,
        fixedHeader: true,
        scrollX: true,
        select: true,
        language: {
            searchPlaceholder: 'Ara',
            lengthMenu: 'Satır Sayısı <select name="dt-basic-example_lenght" aria-controls="dt-basic-exampl" class="form-control custom-select"  style="margin-right:10px;"><option value="10">10</option><option value="20">20</option><option value="50"> 50</option><option value="-1">Hepsi</option></select >',
            info: ""
        }
    });
   

});
