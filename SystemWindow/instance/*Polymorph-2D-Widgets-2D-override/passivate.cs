passivate
	"Make me unable to respond to mouse and keyboard"

	super passivate.
	self setStripeColorsFrom: self paneColorToUse.
	model modelSleep.
	"Control boxes remain active, except in novice mode"
	self lockInactivePortions.
	labelArea ifNil: "i.e. label area is nil, so we're titleless"
		[self adjustBorderUponDeactivationWhenLabeless]