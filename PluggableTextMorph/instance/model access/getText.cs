getText 
	"Retrieve the current model text"

	| newText |
	getTextSelector == nil ifTrue: [^ Text new].
	newText _ model perform: getTextSelector.
	newText ifNil: [^Text new].
	^ newText shallowCopy