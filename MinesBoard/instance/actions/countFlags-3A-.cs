countFlags: location

	| al at flags |
	flags _ 0.
	{-1@-1. -1@0. -1@1. 0@1. 1@1. 1@0. 1@-1. 0@-1} do:
		[:offsetPoint |
		al _ location + offsetPoint.
		((al x between: 1 and: columns) and: [al y between: 1 and: rows]) ifTrue:
			[at _ self tileAt: al.
			(at mineFlag ) ifTrue:
				[flags _ flags+1]]].
		^flags.