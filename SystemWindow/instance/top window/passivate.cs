passivate
	"Make me unable to respond to mouse and keyboard"
	self setStripeColorsFrom: self paneColorToUse.
	model modelSleep.
	self submorphsDo:
		[:m | (m == closeBox or: [m == collapseBox])
				ifTrue: ["Control boxes remain active, except in novice mode"
						Preferences noviceMode ifTrue: [m lock]]
				ifFalse: [m lock]].
	self world ifNotNil:  "clean damage now, so dont merge this rect with new top window"
		[self world == World ifTrue: [self world displayWorld]]