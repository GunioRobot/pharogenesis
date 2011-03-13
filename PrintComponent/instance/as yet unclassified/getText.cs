getText 
	"Retrieve the current model text"

	getTextSelector == nil ifTrue: [^ Text new].
	^ (model perform: getTextSelector) printString asText