editEvent: anEvent for: aMorph

	| answer initialText aFillInTheBlankMorph |

	(aMorph bounds containsPoint: anEvent cursorPoint) ifFalse: [^self].
	initialText _ String streamContents: [ :strm |
		targetIPAddresses do: [ :each | strm nextPutAll: each; cr].
	].
	aFillInTheBlankMorph _ FillInTheBlankMorph new
		setQuery: 'Who are you chatting with?'
		initialAnswer: initialText
		answerHeight: 250
		acceptOnCR: false.
	aFillInTheBlankMorph responseUponCancel: nil.
	self world addMorph: aFillInTheBlankMorph centeredNear: anEvent cursorPoint.
	answer _ aFillInTheBlankMorph getUserResponse.
	answer ifNil: [^self].
	self updateIPAddressField: (answer findTokens: ' ',String cr).

