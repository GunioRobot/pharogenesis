dispatchEvent: event using: aBlock
	"This method is one big and incredibly ugly hack. I hate it."
	| evt hand |
	evt _ event getMorphicEvent copy.
	evt setCursorPoint: (myTexture mapPrimitiveVertex: event getVertex).
	hand _ self getProperty: #stupidHandThatKnowsEverything.
	hand == nil ifTrue:[
		hand _ FakeHandMorph new.
		self setProperty: #stupidHandThatKnowsEverything toValue: hand].
	hand privateOwner: myTexture.
	myTexture isInWorld ifFalse:[myTexture privateOwner: event getCameraMorph].
	aBlock value: evt value: hand.