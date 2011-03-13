color: aColor
	"Check to avoid repeats of the same color."

	aColor ifNil: [^self].
	((self valueOfProperty: #lastColor) = aColor and: [
	self getModelState = (self valueOfProperty: #lastState)])
		ifTrue: [^self].
	super color: aColor.
	Preferences gradientButtonLook ifTrue:[self adoptColor: aColor]