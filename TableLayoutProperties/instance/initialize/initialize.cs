initialize
	super initialize.
	cellSpacing _ listSpacing _ wrapDirection _ #none.
	cellPositioning _ #center.
	listCentering _ wrapCentering _ #topLeft.
	listDirection _ #topToBottom.
	reverseTableCells _ rubberBandCells _ false.
	layoutInset _ cellInset _ minCellSize _ 0.
	maxCellSize _ 1073741823. "SmallInteger maxVal"
