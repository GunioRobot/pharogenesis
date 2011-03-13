sizeOfSTArrayFromCPrimitive: cPtr
	"Return the number of indexable fields of the given object. This method is to be called from an automatically generated C primitive. The argument is assumed to be a pointer to the first indexable field of a words or bytes object; the object header start 4 bytes before that."
	"Note: Only called by translated primitive code."

	| oop |
	self var: #cPtr declareC: 'void *cPtr'.
	oop _ self cCode: '((int) cPtr) - 4'.
	(self isWordsOrBytes: oop) ifFalse: [
		self primitiveFail.
		^ 0].
	^ self lengthOf: oop
