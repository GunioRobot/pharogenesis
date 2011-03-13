getFirstElement
	"Answer a player representing the receiver's costume's first submorph"

	| itsMorphs |
	^ (itsMorphs _ costume submorphs) size > 0
		ifFalse:
			[self standardPlayer]
		ifTrue:
			[itsMorphs first assuredPlayer]