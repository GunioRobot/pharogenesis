rgbMapPixel: sourcePixel shifts: shifts masks: masks
	"Perform the RGBA conversion for the given source pixel"
	| val mask shift |
	self inline: true.
	val _ 0.
	mask _ (self cCoerce: masks to:'int*') at: RedIndex.
	shift _ (self cCoerce: shifts to:'int*') at: RedIndex.
	val _ val bitOr: ((sourcePixel bitAnd: mask) bitShift: shift).
	mask _ (self cCoerce: masks to:'int*') at: GreenIndex.
	shift _ (self cCoerce: shifts to:'int*') at: GreenIndex.
	val _ val bitOr: ((sourcePixel bitAnd: mask) bitShift: shift).
	mask _ (self cCoerce: masks to:'int*') at: BlueIndex.
	shift _ (self cCoerce: shifts to:'int*') at: BlueIndex.
	val _ val bitOr: ((sourcePixel bitAnd: mask) bitShift: shift).
	mask _ (self cCoerce: masks to:'int*') at: AlphaIndex.
	mask = 0 "common case"
		ifFalse:[shift _ (self cCoerce: shifts to:'int*') at: AlphaIndex.
				val _ val bitOr: ((sourcePixel bitAnd: mask) bitShift: shift)].
	"Avoid transparency by color reduction.
	Ugh ... check this!!!"
	(val = 0 and:[sourcePixel ~= 0]) ifTrue:[val _ 1].
	^val