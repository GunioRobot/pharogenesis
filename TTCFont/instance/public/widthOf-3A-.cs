widthOf: aCharacter
	"This method cannot use #formOf: because formOf: discriminates the color and causes unnecessary bitmap creation."
	aCharacter charCode > self maxAscii ifTrue: [
		fallbackFont ifNotNil: [^ fallbackFont widthOf: aCharacter].
		^ 1
	].
	^(self formOf: aCharacter) width