getText
	"Retrieve the current model text"

	| newText |
	getTextSelector isNil ifTrue: [^Text new].
	newText := model perform: getTextSelector.
	newText ifNil: [^Text new].
	^newText shallowCopy