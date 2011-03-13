copyPixelsRGBA: y
	"Handle non-interlaced RGBA color modes (colorType = 6)"

	| i pixel tempForm tempBits |

	tempForm _ Form extent: width@1 depth: 32.
	tempBits _ tempForm bits.
	pixel := LargePositiveInteger new: 4.
	bitsPerChannel = 8 ifTrue: [
		i := -3.
		0 to: width-1 do: [ :x |
			i := i + 4.
			pixel at: 4 put: (thisScanline at: i+3);
				at: 3 put: (thisScanline at: i);
				at: 2 put: (thisScanline at: i+1);
				at: 1 put: (thisScanline at: i+2).
			tempBits at: x+1 put: pixel.
		]
	] ifFalse: [
		i := -7.
		0 to: width-1 do: [ :x |
			i := i + 8.
			pixel at: 4 put: (thisScanline at: i+6);
				at: 3 put: (thisScanline at: i);
				at: 2 put: (thisScanline at: i+2);
				at: 1 put: (thisScanline at: i+4).
			tempBits at: x+1 put: pixel.
		]
	].
	tempForm displayOn: form at: 0@y rule: Form paint.
