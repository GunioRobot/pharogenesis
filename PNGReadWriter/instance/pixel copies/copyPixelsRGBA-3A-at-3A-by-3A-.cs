copyPixelsRGBA: y at: startX by: incX
	"Handle interlaced RGBA color modes (colorType = 6)"

	| i pixel tempForm tempBits |

	tempForm _ Form extent: width@1 depth: 32.
	tempBits _ tempForm bits.
	pixel := LargePositiveInteger new: 4.
	bitsPerChannel = 8 ifTrue: [
		i _ (startX // incX << 2) + 1.
		startX to: width-1 by: incX do: [ :x |
			pixel at: 4 put: (thisScanline at: i+3);
				at: 3 put: (thisScanline at: i);
				at: 2 put: (thisScanline at: i+1);
				at: 1 put: (thisScanline at: i+2).
			tempBits at: x+1 put: pixel.
			i _ i + 4.
		]
	] ifFalse: [
		i _ (startX // incX << 3) +1.
		startX to: width-1 by: incX do: [ :x |
			pixel at: 4 put: (thisScanline at: i+6);
				at: 3 put: (thisScanline at: i);
				at: 2 put: (thisScanline at: i+2);
				at: 1 put: (thisScanline at: i+4).
			tempBits at: x+1 put: pixel.
			i _ i + 8.
		].
	].
	tempForm displayOn: form at: 0@y rule: Form paintAlpha.

