fetchInteger: fieldIndex ofObject: objectPointer
	"Note: May be called by translated primitive code."

	| intOop |
	self inline: false.
	intOop _ self fetchPointer: fieldIndex ofObject: objectPointer.
	(self isIntegerObject: intOop)
		ifTrue: [ ^ self integerValueOf: intOop ]
		ifFalse: [ self primitiveFail. ^ 0 ]