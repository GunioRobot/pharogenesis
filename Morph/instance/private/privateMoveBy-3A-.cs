privateMoveBy: delta 
	"Private! Use 'position:' instead."
	| fill |
	self hasExtension
		ifTrue: [self extension player
				ifNotNil: ["Most cases eliminated fast by above test"
					self getPenDown
						ifTrue: ["If this is a costume for a player with its 
							pen down, draw a line."
							self moveWithPenDownBy: delta]]].
	bounds _ bounds translateBy: delta.
	fullBounds
		ifNotNil: [fullBounds _ fullBounds translateBy: delta].
	fill _ self fillStyle.
	fill isOrientedFill
		ifTrue: [fill origin: fill origin + delta]