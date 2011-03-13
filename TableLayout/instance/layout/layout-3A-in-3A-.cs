layout: aMorph in: box
	"Compute the layout for the given morph based on the new bounds"
	| cells arrangement horizontal newBounds |
	aMorph hasSubmorphs ifFalse:[^self].
	properties _ aMorph assureTableProperties.
	newBounds _ box origin asIntegerPoint corner: (box corner asIntegerPoint).

	(properties wrapDirection == #none and:[properties cellSpacing == #none]) ifTrue:[
		"get into the fast lane"
		properties listCentering == #justified ifFalse:["can't deal with that"
			properties listDirection == #leftToRight 
				ifTrue:[^self layoutLeftToRight: aMorph in: newBounds].
			properties listDirection == #topToBottom
				ifTrue:[^self layoutTopToBottom: aMorph in: newBounds].
		].
	].

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
	"Step 3: Compute the extra spacing for each cell"
	self computeExtraSpacing: arrangement 
		in: newBounds 
		horizontal: horizontal 
		target: aMorph.
	"Step 4: Place the children within the cells accordingly"
	self placeCells: arrangement 
		in: newBounds 
		horizontal: horizontal 
		target: aMorph.