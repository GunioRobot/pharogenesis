privateMoveBy: delta
	"Private! Use 'position:' instead."
	| fill |
	(extension == nil or: [extension player == nil]) ifFalse:
		["Most cases eliminated fast by above test"
		self getPenDown ifTrue:
			["If this is a costume for a player with its pen down, draw a line."
			self moveWithPenDownBy: delta]].
	fullBounds == bounds
		ifTrue: ["optimization: avoids recomputing fullBounds"
				fullBounds _ bounds _ bounds translateBy: delta]
		ifFalse: [bounds _ bounds translateBy: delta.
				fullBounds _ nil].
	fill _ self fillStyle.
	fill isOrientedFill ifTrue:[fill origin: fill origin + delta].
