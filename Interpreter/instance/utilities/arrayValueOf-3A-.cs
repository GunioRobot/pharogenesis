arrayValueOf: arrayOop
	"Return the address of first indexable field of the word or byte arry-like object arrayOop. Fail if arrayOop is not an indexable bytes or words object."
	"Note: May be called by translated primitive code."

	self returnTypeC: 'void *'.
	(self isWordsOrBytes: arrayOop)
		ifTrue: [^ self cCode: '(void *) (arrayOop + 4)'].
	self primitiveFail.
