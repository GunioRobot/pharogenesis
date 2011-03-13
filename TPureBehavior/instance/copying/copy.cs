copy
	"Answer a copy of the receiver without a list of subclasses."

	| myCopy |
	myCopy _ self shallowCopy.
	^myCopy methodDictionary: self copyOfMethodDictionary