selectTilesAdjacentTo: location

	| al at mines |
"	{-1@0. 0@-1. 1@0. 0@1} do:"
	{-1@-1. -1@0. -1@1. 0@1. 1@1. 1@0. 1@-1. 0@-1} do:
		[:offsetPoint |
		al _ location + offsetPoint.
		((al x between: 1 and: columns) and: [al y between: 1 and: rows]) ifTrue:
			[at _ self tileAt: al.
			(at switchState not and: [at disabled not]) ifTrue:
				[
				mines _ (self tileAt: al) nearMines.
				at mineFlag ifTrue: [at mineFlag: false.].  "just in case we flagged it as a mine."
				at switchState: true.
				tileCount _ tileCount + 1.
				mines=0 ifTrue: [self selectTilesAdjacentTo: al]]]]
