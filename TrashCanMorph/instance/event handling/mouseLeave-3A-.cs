mouseLeave: event
	"Present feedback for aborted deletion."
	| hand |
	hand _ event hand.
	((hand submorphCount > 0) and:
	 [hand submorphs first ~~ self])
		ifTrue:
			[Preferences soundsEnabled ifTrue: [self class playMouseLeaveSound].
			hand endDisplaySuppression.
			self state: #off]
		ifFalse:
			[self stopShowingStampIn: hand].
