getText
	"Retrieve the current model text. Set the converter to
	convert between the class of the returned object and string form."

	| newObj |
	getTextSelector isNil ifTrue: [^super getText].
	newObj := model perform: getTextSelector.
	newObj ifNil: [^Text new].
	self converter isNil
		ifTrue: [self convertTo: newObj class].
	^(self converter objectAsString: newObj) shallowCopy