ffiReturnCStringFrom: cPointer
	"Create a Smalltalk string from a zero terminated C string"
	| strLen strOop cString strPtr |
	self var: #cString declareC:'char *cString'.
	self var: #strPtr declareC:'char *strPtr'.
	cPointer = nil ifTrue:[
		^interpreterProxy push: interpreterProxy nilObject]. "nil always returs as nil"
	cString _ self cCoerce: cPointer to:'char *'.
	strLen _ 0.
	[(cString at: strLen) = 0] whileFalse:[strLen _ strLen+1].
	strOop _ interpreterProxy 
				instantiateClass: interpreterProxy classString 
				indexableSize: strLen.
	strPtr _ interpreterProxy firstIndexableField: strOop.
	0 to: strLen-1 do:[:i| strPtr at: i put: (cString at: i)].
	^interpreterProxy push: strOop