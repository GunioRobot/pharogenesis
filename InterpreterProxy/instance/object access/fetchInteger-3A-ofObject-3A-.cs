fetchInteger: fieldIndex ofObject: objectPointer
	"Note: May be called by translated primitive code."

	| intOop |
	self inline: false.
	intOop _ self fetchPointer: fieldIndex ofObject: objectPointer.
	^self checkedIntegerValueOf: intOop