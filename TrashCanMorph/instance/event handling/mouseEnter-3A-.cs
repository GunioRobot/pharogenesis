mouseEnter: event
	"Present feedback for potential deletion."
	| hand firstSub |
	hand _ event hand.
	(((hand submorphCount > 0) and: [(firstSub _ hand submorphs first) ~~ self]) and:
			[self wantsDroppedMorph: firstSub event: event])
		ifTrue: 
			[Preferences soundsEnabled ifTrue: [self class playMouseEnterSound].
			hand visible: false.
			"self world abandonAllHalos."
			"hand halo: nil."
			self state: #pressed]
		ifFalse:
			[self showStampIn: hand]