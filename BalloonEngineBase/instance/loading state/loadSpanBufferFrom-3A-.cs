loadSpanBufferFrom: spanOop
	"Load the span buffer from the given oop."
	self inline: false.
	(interpreterProxy fetchClassOf: spanOop) = (interpreterProxy classBitmap) ifFalse:[^false].
	spanBuffer _ interpreterProxy firstIndexableField: spanOop.
	"Leave last entry unused to avoid complications"
	self spanSizePut: (interpreterProxy slotSizeOf: spanOop) - 1.
	^true