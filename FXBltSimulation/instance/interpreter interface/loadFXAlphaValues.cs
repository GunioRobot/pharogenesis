loadFXAlphaValues
	"Load the source/destination transparency keys"
	| oop |
	self inline: true.
	oop _ interpreterProxy fetchPointer: FXSourceKeyIndex ofObject: bitBltOop.
	srcKeyMode _ (oop ~= interpreterProxy nilObject).
	srcKeyMode 
		ifTrue:[sourceAlphaKey _ self fetchIntOrFloat: FXSourceKeyIndex ofObject: bitBltOop]
		ifFalse:[sourceAlphaKey _ 0].
	oop _ interpreterProxy fetchPointer: FXDestKeyIndex ofObject: bitBltOop.
	dstKeyMode _ (oop ~= interpreterProxy nilObject).
	dstKeyMode 
		ifTrue:[destAlphaKey _ self fetchIntOrFloat: FXDestKeyIndex ofObject: bitBltOop]
		ifFalse:[destAlphaKey _ 0].
	sourceAlpha _ self fetchIntOrFloat: FXSourceAlphaIndex ofObject: bitBltOop ifNil: 255.
	^interpreterProxy failed not