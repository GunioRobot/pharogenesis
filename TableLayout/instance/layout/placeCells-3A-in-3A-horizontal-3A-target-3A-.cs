placeCells: arrangement in: newBounds horizontal: aBool target: aMorph
	"Place the morphs within the cells accordingly"
	| xDir yDir anchor yDist place cell xDist cellRect corner inset |
	inset _ properties cellInset.
	(inset isNumber and:[inset isZero]) ifTrue:[inset _ nil].
	aBool ifTrue:["horizontal layout"
		properties listDirection == #rightToLeft ifTrue:[
			xDir _ -1@0.
			properties wrapDirection == #bottomToTop 
				ifTrue:[yDir _ 0@-1. anchor _ newBounds bottomRight]
				ifFalse:[yDir _ 0@1. anchor _ newBounds topRight].
		] ifFalse:[
			xDir _ 1@0.
			properties wrapDirection == #bottomToTop
				ifTrue:[yDir _ 0@-1. anchor _ newBounds bottomLeft]
				ifFalse:[yDir _ 0@1. anchor _ newBounds topLeft]].
	] ifFalse:["vertical layout"
		properties listDirection == #bottomToTop ifTrue:[
			xDir _ 0@-1.
			properties wrapDirection == #rightToLeft
				ifTrue:[yDir _ -1@0. anchor _ newBounds bottomRight]
				ifFalse:[yDir _ 1@0. anchor _ newBounds bottomLeft]
		] ifFalse:[
			xDir _ 0@1.
			properties wrapDirection == #rightToLeft
				ifTrue:[yDir _ -1@0. anchor _ newBounds topRight]
				ifFalse:[yDir _ 1@0. anchor _ newBounds topLeft]].
	].
	1 to: arrangement size do:[:i|
		cell _ arrangement at: i.
		cell extraSpace ifNotNil:[anchor _ anchor + (cell extraSpace y * yDir)].
		yDist _ cell cellSize y * yDir. "secondary advance direction"
		place _ anchor.
		cell _ cell nextCell.
		[cell == nil] whileFalse:[
			cell extraSpace ifNotNil:[place _ place + (cell extraSpace x * xDir)].
			xDist _ cell cellSize x * xDir. "primary advance direction"
			corner _ place + xDist + yDist.
			cellRect _ Rectangle origin: (place min: corner) corner: (place max: corner).
			inset ifNotNil:[cellRect _ cellRect insetBy: inset].
			cell target layoutInBounds: cellRect.
			place _ place + xDist.
			cell _ cell nextCell].
		anchor _ anchor + yDist.
	].
