computeGlobalCellArrangement: cells in: newBounds horizontal: aBool wrap: wrap spacing: spacing
	"Compute number of cells we can put in each row/column. The returned array contains a list of all the cells we can put into the row/column at each level.
	Note: The arrangement is so that the 'x' value of each cell advances along the list direction and the 'y' value along the wrap direction. The returned arrangement has an extra cell at the start describing the width and height of the row."
	| output maxExtent n cell first last hFill vFill |
	output _ (WriteStream on: Array new).
	first _ last _ nil.
	maxExtent _ cells inject: 0@0 into:[:size :c| size max: c cellSize "e.g., minSize"].
	spacing == #globalSquare ifTrue:[maxExtent _ (maxExtent x max: maxExtent y) asPoint].
	n _ (wrap // maxExtent x) max: 1.
	hFill _ vFill _ false.
	1 to: cells size do:[:i|
		cell _ cells at: i.
		hFill _ hFill or:[cell hSpaceFill].
		vFill _ vFill or:[cell vSpaceFill].
		cell cellSize: maxExtent.
		first ifNil:[first _ last _ cell] ifNotNil:[last nextCell: cell. last _ cell].
		(i \\ n) = 0 ifTrue:[
			last _ LayoutCell new.
			last cellSize: (maxExtent x * n) @ (maxExtent y).
			last hSpaceFill: hFill.
			last vSpaceFill: vFill.
			hFill _ vFill _ false.
			last nextCell: first.
			output nextPut: last.
			first _ nil]].
	first ifNotNil:[
		last _ LayoutCell new.
		last cellSize: (maxExtent x * n) @ (maxExtent y). self flag: #arNote."@@@: n is not correct!"
		last nextCell: first.
		output nextPut: last].
	^output contents
