objectViewed
	"Answer the graphical object to which the receiver's phrases apply"

	^ (scriptedPlayer isKindOf: Player)
		ifTrue:
			[scriptedPlayer costume]
		ifFalse:
			[scriptedPlayer]