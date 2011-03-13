minExtentOf: aMorph in: box
	"Return the minimal size aMorph's children would require given the new bounds"
	| cells arrangement horizontal newBounds minX minY dir |
	minExtentCache == nil ifFalse:[^minExtentCache].
	aMorph hasSubmorphs ifFalse:[^0@0].
	properties _ aMorph assureTableProperties.

	(properties wrapDirection == #none and:[properties cellSpacing == #none]) ifTrue:[
		"Get into the fast lane"
		dir _ properties listDirection.
		(dir == #leftToRight or:[dir == #rightToLeft])
			ifTrue:[^self minExtentHorizontal: aMorph].
		(dir == #topToBottom or:[dir == #bottomToTop])
			ifTrue:[^self minExtentVertical: aMorph].
	].
	newBounds _ box origin asIntegerPoint corner: (box corner asIntegerPoint).
	(properties listDirection == #topToBottom or:[properties listDirection == #bottomToTop])
		ifTrue:[	horizontal _ false]
		ifFalse:[	horizontal _ true].
	"Step 1: Compute the minimum extent for all the children of aMorph"
	cells _ self computeCellSizes: aMorph 
				in: (0@0 corner: newBounds extent) 
				horizontal: horizontal.
	"Step 2: Compute the arrangement of the cells for each row and column"
	arrangement _ self computeCellArrangement: cells 
						in: newBounds 
						horizontal: horizontal
						target: aMorph.
	"Step 3: Extract the minimum size out of the arrangement"
	minX _ minY _ 0.
	arrangement do:[:cell|
		minX _ minX max: cell cellSize x + cell extraSpace x.
		minY _ minY + cell cellSize y + cell extraSpace y].
	horizontal 
		ifTrue:[minExtentCache _ minX@minY]
		ifFalse:[minExtentCache _ minY@minX].
	^minExtentCache