duplicate
	"Usually, FlashMorphs exist in a player. 
	If they're grabbed and moved outside the player
	they should keep their position."

	| dup player |
	dup := super duplicate.
	player := self flashPlayer.
	dup transform: (self transformFrom: self world).
	"If extracted from player and no default AA level is set use prefs"
	(player notNil and: [self defaultAALevel isNil]) 
		ifTrue: 
			[Preferences extractFlashInHighQuality ifTrue: [dup defaultAALevel: 2].
			Preferences extractFlashInHighestQuality ifTrue: [dup defaultAALevel: 4]].
	^dup