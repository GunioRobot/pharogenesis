associatedPlayer
	"Answer the player that's the object of my attention"

	| pp |
	pp _ self firstSubmorph.
	[pp isKindOf: PhraseTileMorph] whileTrue: [pp _ pp firstSubmorph].
	^ pp firstSubmorph actualObject