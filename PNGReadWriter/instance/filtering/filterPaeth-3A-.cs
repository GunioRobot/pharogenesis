filterPaeth: count
	"Select one of (the pixel to the left, the pixel above and the
pixel to above left) to
	predict the value of this pixel"

	| delta this left above aboveLeft |
	delta _ bitsPerPixel // 8 max: 1.
	1 to: delta do: [ :i |
		thisScanline at: i put:
			(((thisScanline at: i) + (prevScanline at: i))
bitAnd: 255)
		].
	delta+1 to: count do: [ :i |
		this _ thisScanline at: i.
		left _ thisScanline at: i-delta.
		above _ prevScanline at: i.
		aboveLeft _ prevScanline at: i-delta.
		thisScanline at: i put:
		((this + (self paethPredictLeft: left above: above
aboveLeft: aboveLeft)) bitAnd: 255) ]

