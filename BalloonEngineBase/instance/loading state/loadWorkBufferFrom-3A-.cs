loadWorkBufferFrom: wbOop
	"Load the working buffer from the given oop"
	self inline: false.
	(interpreterProxy isIntegerObject: wbOop) ifTrue:[^false].
	(interpreterProxy isWords: wbOop) ifFalse:[^false].
	(interpreterProxy slotSizeOf: wbOop) < GWMinimalSize ifTrue:[^false].
	workBuffer _ interpreterProxy firstIndexableField: wbOop.
	self magicNumberGet = GWMagicNumber ifFalse:[^false].
	"Sanity checks"
	(self wbSizeGet = (interpreterProxy slotSizeOf: wbOop)) ifFalse:[^false].
	self objStartGet = GWHeaderSize ifFalse:[^false].

	"Load buffers"
	objBuffer _ workBuffer + self objStartGet.
	getBuffer _ objBuffer + self objUsedGet.
	aetBuffer _ getBuffer + self getUsedGet.

	"Make sure we don't exceed the work buffer"
	GWHeaderSize + self objUsedGet + self getUsedGet + self aetUsedGet > self wbSizeGet ifTrue:[^false].

	^true