fixLayout
	"Pack my submorphs into rows that fit within my width, if autoLineLayout is true."

	| nextY i morphsForThisRow |
	self invalidRect: bounds.
	self autoLineLayout ifTrue:
		[nextY _ bounds top + borderWidth.
		i _ 1.
		[i <= submorphs size] whileTrue:
			[morphsForThisRow _ self rowMorphsStartingAt: i.
			nextY _ self layoutRow: morphsForThisRow lastRowBase: nextY.
			i _ i + morphsForThisRow size]]
