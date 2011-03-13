passivate
	"Make me unable to respond to mouse and keyboard"
	self submorphsDo: [:m | m lock].
	self setStripeColorsFrom: self paneColor.
	self removeHandles