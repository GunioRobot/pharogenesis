findMines: location

	| al at mines |
	mines _ 0.
	{-1@-1. -1@0. -1@1. 0@1. 1@1. 1@0. 1@-1. 0@-1} do:
		[:offsetPoint |
		al _ location + offsetPoint.
		((al x between: 1 and: columns) and: [al y between: 1 and: rows]) ifTrue:
			[at _ self tileAt: al.
			(at isMine ) ifTrue:
				[mines _ mines+1]]].
		^mines.