color: sensitiveColor sees: soughtColor
	"Return true if any of my pixels of sensitiveColor intersect with pixels of soughtColor."

	| myImage sensitivePixelMask map canvas myBnds w |
	"make a mask with black where sensitiveColor is, white elsewhere"
	myImage _ self imageForm.
	sensitivePixelMask _ Form extent: myImage extent depth: 1.
	map _ (Color cachedColormapFrom: myImage depth to: 1) copy.
	map primFill: 0.
	map at: (sensitiveColor indexInMap: map) put: 1.
	sensitivePixelMask copyBits: sensitivePixelMask boundingBox
		from: myImage form
		at: 0@0
		colorMap: map.

	"get an image of the world without me"
	myBnds _ self fullBounds.
	canvas _ (FormCanvas extent: myBnds extent) copyOffset: myBnds topLeft negated.
	canvas _ canvas copyClipRect: myBnds.
	w _ self world.
	w fullDrawOn: canvas butDoNotDraw: self.
	w hands reverseDo: [:h | h fullDrawOn: canvas butDoNotDraw: self].

	"intersect world pixels of the color we're looking for with the sensitive pixels"
	map at: (sensitiveColor indexInMap: map) put: 0.  "clear map and reuse it"
	map at: (soughtColor indexInMap: map) put: 1.
	sensitivePixelMask copyBits: canvas form boundingBox
		from: canvas form
		at: 0@0
		clippingBox: canvas form boundingBox
		rule: Form and
		fillColor: nil
		map: map.

	^ (sensitivePixelMask tallyPixelValues at: 2) > 0
