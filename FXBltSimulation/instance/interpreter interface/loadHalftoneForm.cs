loadHalftoneForm
	"Load the halftone form"
	| halftoneBits |
	self inline: true.
	halftoneForm _ interpreterProxy fetchPointer: BBHalftoneFormIndex ofObject: bitBltOop.
	noHalftone _ self ignoreSourceOrHalftone: halftoneForm.
	noHalftone ifTrue:[
		halftoneBase _ nil.
		^true].
	((interpreterProxy isPointers: halftoneForm) not
		and: [interpreterProxy isWords: halftoneForm])
			ifFalse: [^ false].
	halftoneBits _ halftoneForm.
	halftoneHeight _ interpreterProxy slotSizeOf: halftoneBits.
	halftoneBase _ self cCoerce: (interpreterProxy firstIndexableField: halftoneBits) to:'int'.
	^true