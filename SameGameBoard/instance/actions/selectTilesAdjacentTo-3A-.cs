selectTilesAdjacentTo: location

	| al at |
	{-1@0. 0@-1. 1@0. 0@1} do:
		[:offsetPoint |
		al _ location + offsetPoint.
		((al x between: 0 and: columns - 1) and: [al y between: 0 and: rows - 1]) ifTrue:
			[at _ self tileAt: al.
			(at color = selectionColor and: [at switchState not and: [at disabled not]]) ifTrue:
				[selection add: al.
				at setSwitchState: true.
				self selectTilesAdjacentTo: al]]]
