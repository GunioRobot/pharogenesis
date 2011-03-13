privateMoveBy: delta 
	"Private! Use 'position:' instead."
	| fill border|
	extension ifNotNil: [extension player
				ifNotNil: ["Most cases eliminated fast by above test"
					self getPenDown
						ifTrue: ["If this is a costume for a player with its 
							pen down, draw a line."
							self moveWithPenDownBy: delta]]].
	bounds := bounds translateBy: delta.
	fullBounds ifNotNil: [fullBounds := fullBounds translateBy: delta].
	fill := self fillStyle.
	fill isOrientedFill ifTrue: [fill origin: fill origin + delta].
	border := self borderStyle.
	(border hasFillStyle and: [border fillStyle isOrientedFill]) ifTrue: [
		border fillStyle origin: border fillStyle origin + delta]