primMapFrom: srcBitmap to: dstBitmap width: w height: h patchSize: patchSize rgbFlags: rgbFlags shift: shiftAmount 
	"Map values in the source bitmap (interpreted as unsigned 32-bit integers) to 2x2 patches of color in the destination bitmap. The color brightness level is determined by the source value and the color hue is determined by the bottom three bits of the rgbFlags value. For example, if rgbFlags is 1, you get shades of blue, if it is 6 you get shades of yellow, and if it is 7, you get shades of gray. The shiftAmount is used to scale the source data values by a power of two. If shiftAmount is zero, the data is unscaled. Positive shiftAmount values result in right shifting the source data by the given number of bits (multiplying by 2^N, negative values perform right shifts (dividing by 2^N). The width parameter gives the width of the Form that owns the destination bitmap."

	| rgbMult srcIndex level pixel offset |
	<primitive: 'primitiveMapFromToWidthHeightPatchSizeRgbFlagsShift' module: 'StarSqueakPlugin'>
	rgbMult := 0.
	(rgbFlags bitAnd: 4) > 0 ifTrue: [rgbMult := rgbMult + 65536].
	(rgbFlags bitAnd: 2) > 0 ifTrue: [rgbMult := rgbMult + 256].
	(rgbFlags bitAnd: 1) > 0 ifTrue: [rgbMult := rgbMult + 1].
	srcIndex := 0.
	0 to: h // patchSize - 1
		do: 
			[:y | 
			0 to: w // patchSize - 1
				do: 
					[:x | 
					level := (srcBitmap at: (srcIndex := srcIndex + 1)) bitShift: shiftAmount.
					level := level min: 255.
					pixel := level <= 0 
								ifTrue: 
									["non-transparent black"

									1]
								ifFalse: [level * rgbMult].

					"fill a patchSize x patchSize square with the pixel value"
					offset := (y * w + x) * patchSize.
					offset to: offset + ((patchSize - 1) * w)
						by: w
						do: 
							[:rowStart | 
							rowStart + 1 to: rowStart + patchSize
								do: [:dstIndex | dstBitmap at: dstIndex put: pixel]]]]