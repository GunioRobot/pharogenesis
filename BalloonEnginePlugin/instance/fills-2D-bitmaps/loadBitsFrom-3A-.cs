loadBitsFrom: bmFill
	"Note: Assumes that the contents of formArray has been checked before"
	| xIndex formOop bitsOop bitsLen |
	self returnTypeC:'int *'.
	xIndex _ self objectIndexOf: bmFill.
	xIndex > (interpreterProxy slotSizeOf: formArray) ifTrue:[^nil].
	formOop _ interpreterProxy fetchPointer: xIndex ofObject: formArray.
	bitsOop _ interpreterProxy fetchPointer: 0 ofObject: formOop.
	bitsLen _ interpreterProxy slotSizeOf: bitsOop.
	bitsLen = (self bitmapSizeOf: bmFill) ifFalse:[^nil].
	^interpreterProxy firstIndexableField: bitsOop