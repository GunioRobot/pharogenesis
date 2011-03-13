getText 
	"Retrieve the current model text"

	getTextSelector == nil ifTrue: [^ Text new].
	^ (model perform: getTextSelector) ifNil: [Text new]