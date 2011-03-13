yTallyPixelValue: pv orNot: not
	"Return an array of the number of pixels with value pv by y-value.
	Note that if not is true, then this will tally those different from pv."
	| cm slice copyBlt countBlt |
	cm := self newColorMap.		"Map all colors but pv to zero"
	not ifTrue: [cm atAllPut: 1].		"... or all but pv to one"
	cm at: pv+1 put: 1 - (cm at: pv+1).
	slice := Form extent: width@1.
	copyBlt := (BitBlt current destForm: slice sourceForm: self
				halftoneForm: nil combinationRule: Form over
				destOrigin: 0@0 sourceOrigin: 0@0 extent: slice width @ 1
				clipRect: slice boundingBox) colorMap: cm.
	countBlt := (BitBlt current toForm: slice)
				fillColor: (Bitmap with: 0);
				destRect: (0@0 extent: slice extent);
				combinationRule: 32.
	^ (0 to: height-1) collect:
		[:y |
		copyBlt sourceOrigin: 0@y; copyBits.
		countBlt copyBits]