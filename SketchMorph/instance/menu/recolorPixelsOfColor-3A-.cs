recolorPixelsOfColor: evt

	| c d newForm map newC |
	c _ evt hand chooseColor.  "color to replace"
	newC _ evt hand chooseColor.  "new color"
	d _ originalForm depth.
	newForm _ Form extent: originalForm extent depth: d.
	map _ (Color cachedColormapFrom: d to: d) copy.
	map at: (c indexInMap: map) put: (newC pixelValueForDepth: d).
	newForm copyBits: newForm boundingBox
		from: originalForm at: 0@0
		colorMap: map.
	self form: newForm.
