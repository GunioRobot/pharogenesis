bitmapValue: bmFill bits: bits atX: xp y: yp
	| bmDepth bmRaster value rShift cMask r g b a |
	self inline: true.
	bmDepth _ self bitmapDepthOf: bmFill.
	bmRaster _ self bitmapRasterOf: bmFill.
	bmDepth = 32 ifTrue:[
		value _ (self cCoerce: bits to:'int*') at: (bmRaster * yp) + xp.
		(value ~= 0 and:[(value bitAnd: 16rFF000000) = 0])
				ifTrue:[value _ value bitOr: 16rFF000000].
		^self uncheckedTransformColor: value].
	"rShift - shift value to convert from pixel to word index"
	rShift _ self rShiftTable at: bmDepth.
	value _ self makeUnsignedFrom: 
		((self cCoerce: bits to:'int*') at: (bmRaster * yp) + (xp >> rShift)).
	"cMask - mask out the pixel from the word"
	cMask _ (1 << bmDepth) - 1.
	"rShift - shift value to move the pixel in the word to the lowest bit position"
	rShift _ 32 - bmDepth - ((xp bitAnd: (1 << rShift - 1)) * bmDepth).
	value _ (value >> rShift) bitAnd: cMask.
	bmDepth = 16 ifTrue:[
		"Must convert by expanding bits"
		value = 0 ifFalse:[
			b _ (value bitAnd: 31) << 3.		b _ b + (b >> 5).
			g _ (value >> 5 bitAnd: 31) << 3.	g _ g + (g >> 5).
			r _ (value >> 10 bitAnd: 31) << 3.	r _ r + (r >> 5).
			a _ 255.
			value _ b + (g << 8) + (r << 16) + (a << 24)].
	] ifFalse:[
		"Must convert by using color map"
		(self bitmapCmSizeOf: bmFill) = 0
			ifTrue:[value _ 0]
			ifFalse:[value _ self makeUnsignedFrom: ((self colormapOf: bmFill) at: value)].
	].
	^self uncheckedTransformColor: value.