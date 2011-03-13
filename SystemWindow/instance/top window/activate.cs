activate
	"Bring me to the front and make me able to respond to mouse and keyboard"
	| oldTop |
	oldTop _ TopWindow.
	TopWindow _ self.
	oldTop ifNotNil: [oldTop passivate].
	owner firstSubmorph == self ifFalse: [owner addMorphFront: self].
	self submorphsDo: [:m | m unlock].
	self setStripeColorsFrom: self paneColor.
	self addHandles
