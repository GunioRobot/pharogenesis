computeCellSizes: aMorph in: newBounds horizontal: aBool
	"Step 1: Compute the minimum extent for all the children of aMorph"
	| cells cell size block maxCell minSize maxSize |
	cells _ WriteStream on: (Array new: aMorph submorphCount).
	minSize _ properties minCellSize asPoint.
	maxSize _ properties maxCellSize asPoint.
	aBool ifTrue:[
		minSize _ minSize transposed.
		maxSize _ maxSize transposed].
	maxCell _ 0@0.
	block _ [:m|
		m disableTableLayout ifFalse:[
			size _ m minExtent asIntegerPoint.
			cell _ LayoutCell new target: m.
			aBool ifTrue:[
				cell hSpaceFill: m hResizing == #spaceFill.
				cell vSpaceFill: m vResizing == #spaceFill.
			] ifFalse:[
				cell hSpaceFill: m vResizing == #spaceFill.
				cell vSpaceFill: m hResizing == #spaceFill.
				size _ size transposed.
			].
			size _ (size min: maxSize) max: minSize.
			cell cellSize: size.
			maxCell _ maxCell max: size.
			cells nextPut: cell]].
	properties reverseTableCells
		ifTrue:[aMorph submorphsReverseDo: block]
		ifFalse:[aMorph submorphsDo: block].
	^maxCell -> cells contents