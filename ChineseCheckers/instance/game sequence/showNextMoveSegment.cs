showNextMoveSegment
	"Display the current move in progress.  Starts with movePhase = 1.
	Increments movePhase at each tick.  Ends by setting movePhase to 0."

	| dot p1 p2 delta secondPhase line |
	delta _ self width//40.
	movePhase <= plannedMove size
	ifTrue:
		["First we trace the move with dots and lines..."
		movePhase = 1 ifTrue: [pathMorphs _ OrderedCollection new].
		p1 _ self cellPointAt: (plannedMove at: movePhase).
		dot _ (ImageMorph new image: (Form dotOfSize: 7)) position: p1 + delta - (7//2).
		self addMorph: dot.  pathMorphs addLast: dot.
		movePhase > 1 ifTrue:
			[p2 _ self cellPointAt: (plannedMove at: movePhase-1).
			line _ PolygonMorph vertices: {p2 + delta. p1 + delta} color: Color black
					borderWidth: 3 borderColor: Color black.
			self addMorph: line.  pathMorphs addLast: line]]
	ifFalse:
		["...then we erase the path while moving the piece."
		secondPhase _ movePhase - plannedMove size.
		pathMorphs removeFirst delete.
		secondPhase > 1 ifTrue:
			[pathMorphs removeFirst delete.
			self makeMove: {plannedMove at: secondPhase - 1. plannedMove at: secondPhase}.
			(self pieceAt: (plannedMove at: secondPhase - 1))
				position: (self cellPointAt: (plannedMove at: secondPhase));
				setBoard: self loc: (plannedMove at: secondPhase).
			self changed]].

	(movePhase _ movePhase + 1) > (plannedMove size * 2)
		ifTrue: [movePhase _ 0  "End of animated move"].

