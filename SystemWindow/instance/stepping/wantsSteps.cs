wantsSteps
	"Return true if the model wants its view to be stepped."
	self isPartsDonor ifTrue: [^ false].
	self player wantsSteps ifTrue: [^ true].
	^ model wantsStepsIn: self