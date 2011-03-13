acceptTextInModel
	"Inform the model that the receiver's textMorph's text should be accepted.
	Answer true if the model accepted ok, false otherwise"
	
	| objectToAccept |
	objectToAccept := self converter isNil
		ifTrue: [textMorph asText]
		ifFalse: [self converter stringAsObject: textMorph asText asString].
	^setTextSelector isNil or:
		[setTextSelector numArgs = 2
			ifTrue: [model perform: setTextSelector with: objectToAccept with: self]
			ifFalse: [model perform: setTextSelector with: objectToAccept]]
