loadHalftoneForm
	"Load the halftone form"
	| halftoneBits |
	self inline: true.
	noHalftone ifTrue:[
		halftoneBase _ nil.
		^true].
	((interpreterProxy isPointers: halftoneForm) and: [(interpreterProxy slotSizeOf: halftoneForm) >= 4])
		ifTrue:
		["Old-style 32xN monochrome halftone Forms"
		halftoneBits _ interpreterProxy fetchPointer: FormBitsIndex ofObject: halftoneForm.
		halftoneHeight _ interpreterProxy fetchInteger: FormHeightIndex ofObject: halftoneForm.
		(interpreterProxy isWords: halftoneBits)
			ifFalse: [noHalftone _ true]]
		ifFalse:
		["New spec accepts, basically, a word array"
		((interpreterProxy isPointers: halftoneForm) not
			and: [interpreterProxy isWords: halftoneForm])
			ifFalse: [^ false].
		halftoneBits _ halftoneForm.
		halftoneHeight _ interpreterProxy slotSizeOf: halftoneBits].
	halftoneBase _ self cCoerce: (interpreterProxy firstIndexableField: halftoneBits) to:'int'.
	^true