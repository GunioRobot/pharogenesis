copy
	"Answer a copy of the receiver without a list of subclasses."

	| myCopy |
	myCopy := self shallowCopy.
	^myCopy methodDictionary: self copyOfMethodDictionary