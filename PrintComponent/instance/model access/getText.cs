getText
	"Retrieve the current model text"

	getTextSelector isNil ifTrue: [^Text new].
	^(model perform: getTextSelector) printString asText