widthOf: aCharacter

	"This method cannot use #formOf: because formOf: discriminates the color and causes unnecessary bitmap creation."

	| f assoc |
	aCharacter charCode > 255 ifTrue: [
		fallbackFont ifNotNil: [^ fallbackFont widthOf: aCharacter].
		^ 1
	].
	assoc := self cache at: (aCharacter charCode + 1).
	assoc ifNotNil: [
		^ assoc value width
	].

	f := self computeForm: aCharacter.
	self at: aCharacter charCode put: f.
	^ f width.
