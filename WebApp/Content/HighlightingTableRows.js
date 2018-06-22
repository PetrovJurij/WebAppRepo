function tableHighlightRow() {
    if (document.getElementById && document.createTextNode) {
        var tables = document.getElementsByTagName('table');
        for (var i = 0; i < tables.length; i++) {
            if (tables[i].className === 'TableListJS') {
                var trs = tables[i].getElementsByTagName('tr');
                for (var j = 0; j < trs.length; j++) {
                    trs[j].onmousedown = function () {
                        //
                        // Toggle the selected state of this row
                        // 

                        // 'clicked' color is set in tablelist.css.
                        if (this.className !== 'clicked') {
                            // Clear previous selection
                            if (selected !== null) {
                                selected.className = '';
                            }

                            // Mark this row as selected
                            this.className = 'clicked';
                            selected = this;
                        }
                        else {
                            this.className = '';
                            selected = null;
                        }

                        return true
                    }                    
                }
            }
        }
    }
}