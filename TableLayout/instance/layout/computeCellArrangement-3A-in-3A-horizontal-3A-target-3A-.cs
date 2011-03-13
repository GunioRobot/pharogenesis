computeCellArrangement: cellHolder in: newBounds horizontal: aBool target: aMorph
	"Compute number of cells we can put in each row/column. The returned array contains a list of all the cells we can put into the row/column at each level.
	Note: The arrangement is so that the 'x' value of each cell advances along the list direction and the 'y' value along the wrap direction. The returned arrangement has an extra cell at the start describing the width and height of the row."
	| cells wrap spacing output maxExtent n sum index max cell first last w cellMax maxCell hFill vFill inset |
	maxCell _ cellHolder key.
	cells _ cellHolder value.
	properties wrapDirection == #none 
		ifTrue:[wrap _ SmallInteger maxVal]
		ifFalse:[wrap _ aBool ifTrue:[newBounds width] ifFalse:[newBounds height].
				wrap < maxCell x ifTrue:[wrap _ maxCell x]].
	spacing _ properties cellSpacing.
	(spacing == #globalRect or:[spacing = #globalSquare]) ifTrue:[
		"Globally equal spacing is a very special case here, so get out fast and easy"
		^self computeGlobalCellArrangement: cells 
			in: newBounds horizontal: aBool 
			wrap: wrap spacing: spacing].

	output _ (WriteStream on: Array new).
	inset _ properties cellInset asPoint.
	aBool ifFalse:[inset _ inset transposed].
	first _ last _ nil.
	maxExtent _ 0@0.
	sum _ 0.
	index _ 1.
	n _ 0.
	hFill _ vFill _ false.
	[index <= cells size] whileTrue:[
		w _ sum.
		cell _ cells at: index.
		cellMax _ maxExtent max: cell cellSize. "e.g., minSize"
		(spacing == #localRect or:[spacing == #localSquare]) ifTrue:[
			"Recompute entire size of current row"
			spacing == #localSquare 
				ifTrue:[max _ cellMax x max: cellMax y]
				ifFalse:[max _ cellMax x].
			sum _ (n + 1) * max.
		] ifFalse:[
			sum _ sum + (cell cellSize x).
		].
		((sum + (n * inset x)) > wrap and:[first notNil]) ifTrue:[
			"It doesn't fit and we're not starting a new line"
			(spacing == #localSquare or:[spacing == #localRect]) ifTrue:[
				spacing == #localSquare 
					ifTrue:[maxExtent _ (maxExtent x max: maxExtent y) asPoint].
				first do:[:c| c cellSize: maxExtent]].
			w _ w + ((n - 1) * inset x).
			"redistribute extra space"
			first nextCell ifNotNil:[first nextCell do:[:c| c addExtraSpace: inset x@0]].
			last _ LayoutCell new.
			last cellSize: w @ (maxExtent y).
			last hSpaceFill: hFill.
			last vSpaceFill: vFill.
			last nextCell: first.
			output position = 0 ifFalse:[last addExtraSpace: 0@inset y].
			output nextPut: last.
			first _ nil.
			maxExtent _ 0@0.
			sum _ 0.
			n _ 0.
			hFill _ vFill _ false.
		] ifFalse:[
			"It did fit; use next item from input"
			first ifNil:[first _ last _ cell] ifNotNil:[last nextCell: cell. last _ cell].
			index _ index+1.
			n _ n + 1.
			maxExtent _ cellMax.
			hFill _ hFill or:[cell hSpaceFill].
			vFill _ vFill or:[cell vSpaceFill].
		].
	].
	first ifNotNil:[
		last _ LayoutCell new.
		sum _ sum + ((n - 1) * inset x).
		first nextCell ifNotNil:[first nextCell do:[:c| c addExtraSpace: inset x@0]].
		last cellSize: sum @ maxExtent y.
		last hSpaceFill: hFill.
		last vSpaceFill: vFill.
		last nextCell: first.
		output position = 0 ifFalse:[last addExtraSpace: 0@inset y].
		output nextPut: last].
	output _ output contents.
	properties listSpacing == #equal ifTrue:[
		"Make all the heights equal"
		max _ output inject: 0 into:[:size :c| size max: c cellSize y].
		output do:[:c| c cellSize: c cellSize x @ max].
	].
	^output