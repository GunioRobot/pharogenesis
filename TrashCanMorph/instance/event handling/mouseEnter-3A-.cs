mouseEnter: event
	"Present feedback for potential deletion."
	| hand |
	hand _ event hand.
	((hand submorphCount > 0) and:
	 [hand submorphs first ~~ self])
		ifTrue: [
			Preferences soundsEnabled ifTrue: [self class playMouseEnterSound].
			hand startDisplaySuppression.
			self world abandonAllHalos.
			self state: #pressed]
		ifFalse: [
			self showStampIn: hand].
