ordinalNumber
	"Answer a number indicating the relative position of the receiver in its stack, if any, else 1"

	| aStack |
	^ (aStack _ self stack) ifNotNil: [aStack cardIndexOf: self] ifNil: [nil]