createRow
	"create a row"
	| row |
	row := AlignmentMorph newRow.
	row layoutInset: 3;
		 wrapCentering: #center;
		 cellPositioning: #leftCenter.
	""
	^ row