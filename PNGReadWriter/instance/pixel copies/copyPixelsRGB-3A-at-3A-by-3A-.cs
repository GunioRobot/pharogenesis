copyPixelsRGB: y at: startX by: incX 
	"Handle interlaced RGB color mode (colorType = 2)"
	| i pixel tempForm tempBits xx loopsToDo |
	tempForm := Form 
		extent: width @ 1
		depth: 32.
	tempBits := tempForm bits.
	pixel := LargePositiveInteger new: 4.
	pixel 
		at: 4
		put: 255.
	loopsToDo := (width - startX + incX - 1) // incX.
	bitsPerChannel = 8 
		ifTrue: 
			[ i := startX // incX * 3 + 1.
			xx := startX + 1.
			1 
				to: loopsToDo
				do: 
					[ :j | 
					pixel
						at: 3
							put: (thisScanline at: i);
						at: 2
							put: (thisScanline at: i + 1);
						at: 1
							put: (thisScanline at: i + 2).
					tempBits 
						at: xx
						put: pixel.
					i := i + 3.
					xx := xx + incX ] ]
		ifFalse: 
			[ i := startX // incX * 6 + 1.
			xx := startX + 1.
			1 
				to: loopsToDo
				do: 
					[ :j | 
					pixel
						at: 3
							put: (thisScanline at: i);
						at: 2
							put: (thisScanline at: i + 2);
						at: 1
							put: (thisScanline at: i + 4).
					tempBits 
						at: xx
						put: pixel.
					i := i + 6.
					xx := xx + incX ] ].
	transparentPixelValue ifNotNil: 
		[ startX 
			to: width - 1
			by: incX
			do: 
				[ :x | 
				(tempBits at: x + 1) = transparentPixelValue ifTrue: 
					[ tempBits 
						at: x + 1
						put: 0 ] ] ].
	tempForm 
		displayOn: form
		at: 0 @ y
		rule: Form paint