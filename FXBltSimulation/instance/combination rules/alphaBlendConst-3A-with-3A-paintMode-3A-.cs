alphaBlendConst: sourceWord with: destinationWord paintMode: paintMode
	"Blend sourceWord with destinationWord using a constant alpha.
	Alpha is encoded as 0 meaning 0.0, and 255 meaning 1.0.
	The blend produced is alpha*source + (1.0-alpha)*dest, with the
	computation being performed independently on each color component.
	This function could eventually blend into any depth destination,
	using the same color averaging and mapping as warpBlt.
	paintMode = true means do nothing if the source pixel value is zero."

	"This first implementation works with dest depths of 16 and 32 bits only.
	Normal color mapping will allow sources of lower depths in this case,
	and results can be mapped directly by truncation, so no extra color maps are needed.
	To allow storing into any depth will require subsequent addition of two other
	colormaps, as is the case with WarpBlt."

	| pixMask destShifted sourceShifted destPixVal rgbMask sourcePixVal unAlpha result pixBlend shift blend maskShifted bitsPerColor ppw |
	self inline: false.
	pixelDepth < 16 ifTrue: [^ destinationWord "no-op"].
	unAlpha _ 255 - sourceAlpha.
	pixMask _ maskTable at: pixelDepth.
	pixelDepth = 16 
		ifTrue: [bitsPerColor _ 5. ppw _ 2]
		ifFalse:[bitsPerColor _ 8. ppw _ 1].
	rgbMask _ (1<<bitsPerColor) - 1.
	maskShifted _ destMask.
	destShifted _ destinationWord.
	sourceShifted _ sourceWord.
	result _ destinationWord.
	1 to: ppw do:
		[:j |
		sourcePixVal _ sourceShifted bitAnd: pixMask.
		((maskShifted bitAnd: pixMask) = 0  "no effect if outside of dest rectangle"
			or: [paintMode & (sourcePixVal = 0)  "or painting a transparent pixel"])
		ifFalse:
			[destPixVal _ destShifted bitAnd: pixMask.
			pixBlend _ 0.
			1 to: 3 do:
				[:i | shift _ (i-1)*bitsPerColor.
				blend _ (((sourcePixVal>>shift bitAnd: rgbMask) * sourceAlpha)
							+ ((destPixVal>>shift bitAnd: rgbMask) * unAlpha))
					 	+ 254 // 255 bitAnd: rgbMask.
				pixBlend _ pixBlend bitOr: blend<<shift].
			pixelDepth = 16
				ifTrue: [result _ (result bitAnd: (pixMask << (j-1*16)) bitInvert32)
									bitOr: pixBlend << (j-1*16)]
				ifFalse: [result _ pixBlend]].
		maskShifted _ maskShifted >> pixelDepth.
		sourceShifted _ sourceShifted >> pixelDepth.
		destShifted _ destShifted >> pixelDepth].
	^ result
