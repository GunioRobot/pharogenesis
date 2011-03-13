passivate
	"Make me unable to respond to mouse and keyboard"
	self setStripeColorsFrom: self paneColorToUse.
	model modelSleep.

	"Control boxes remain active, except in novice mode"
	self submorphsDo: [:m |
		m == labelArea ifFalse: [
			m lock
		]
	].
	labelArea submorphsDo: [:m |
		(m == closeBox or: [m == collapseBox]) ifTrue: [
			Preferences noviceMode ifTrue: [m lock]
		] ifFalse: [
			m lock
		]
	].
	self world ifNotNil:  "clean damage now, so dont merge this rect with new top window"
		[self world == Display bestGuessOfCurrentWorld ifTrue: [self world displayWorld]].
