readIndexedBmpFile: colors
	"Read uncompressed pixel data of depth d from the given BMP stream, where d is 1, 4, 8, or 16"
	| form bytesPerRow pixelData pixelLine startIndex cm word formBits |
	colors 
		ifNil:[form _ Form extent: biWidth@biHeight depth: biBitCount]
		ifNotNil:[form _ ColorForm extent: biWidth@biHeight depth: biBitCount.
				form colors: colors].
	bytesPerRow _ (((biBitCount* biWidth) + 31) // 32) * 4.
	pixelData _ ByteArray new: bytesPerRow * biHeight.
	biHeight to: 1 by: -1 do: [:y |
		pixelLine _ stream next: bytesPerRow.
		startIndex _ ((y - 1) * bytesPerRow) + 1.
		pixelData 
			replaceFrom: startIndex 
			to: startIndex + bytesPerRow - 1 
			with: pixelLine 
			startingAt: 1].
	form bits copyFromByteArray: pixelData.
	biBitCount = 16 ifTrue:[
		"swap red and blue components"
		cm _ Bitmap new: (1 << 15).
		word _ 0.
		0 to: 31 do:[:r| 0 to: 31 do:[:g| 0 to: 31 do:[:b|
			cm at: (word _ word + 1) put: (b bitShift: 10) + (g bitShift: 5) + r]]].
		cm at: 1 put: 1.
		formBits _ form bits.
		1 to: formBits size do:[:i|
			word _ formBits at: i.
			word _ (cm at: (word bitAnd: 16r7FFF) + 1) + ((cm at: ((word bitShift: -16) bitAnd: 16r7FFF) +1) bitShift: 16).
			formBits at: i put: word.
		].
	].
	^ form
