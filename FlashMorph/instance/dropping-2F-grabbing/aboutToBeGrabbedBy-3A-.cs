aboutToBeGrabbedBy: aHand 
	"Usually, FlashMorphs exist in a player. 
	If they're grabbed and moved outside the player
	they should keep their position."

	| player |
	super aboutToBeGrabbedBy: aHand.
	player := self flashPlayer.
	player ifNotNil: [player noticeRemovalOf: self].
	self transform: (self transformFrom: self world).
	"If extracted from player and no default AA level is set use prefs"
	(player notNil and: [self defaultAALevel isNil]) 
		ifTrue: 
			[Preferences extractFlashInHighQuality ifTrue: [self defaultAALevel: 2].
			Preferences extractFlashInHighestQuality ifTrue: [self defaultAALevel: 4]].
	^self	"Grab me"