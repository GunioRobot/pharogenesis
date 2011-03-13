morphPreceding: aSubmorph
	"Answer the morph immediately preceding aSubmorph, or nil if none"

	| anIndex |
	anIndex _ submorphs indexOf: aSubmorph ifAbsent: [^ nil].
	^ anIndex > 1
		ifTrue:
			[submorphs at: (anIndex - 1)]
		ifFalse:
			[nil]