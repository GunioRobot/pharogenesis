readBody

	| array scanLine rowBytes position byte count pad |
	pad _ #(0 3 2 1) at: (width \\ 4 + 1).
	array _ ByteArray new: ((width + pad) * height * bitsPerPixel) // 8.
	scanLine _ ByteArray new: rowByteSize.
	position _ 1.
	1 to: height do:
		[:line |
		rowBytes _ 0.
		[rowBytes < rowByteSize] whileTrue:
			[byte _ self next.
			byte < 16rC0
				ifTrue:
					[rowBytes _ rowBytes + 1.
					scanLine at: rowBytes put: byte]
				ifFalse:
					[count _ byte - 16rC0.
					byte _ self next.
					1 to: count do: [:i | scanLine at: rowBytes + i put: byte].
					rowBytes _ rowBytes + count]].
		array
			replaceFrom: position
			to: position + width - 1
			with: scanLine
			startingAt: 1.
		position _ position + width + pad].
	^ array
