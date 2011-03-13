recolorPixelsOfColor: evt
	"Let the user select a color to be remapped, and then a color to map that color to, then carry it out."

	| c d newForm map newC |
	self inform: 'choose the color you want to replace'.
	self changeColorTarget: self selector: #rememberedColor: originalColor: nil hand: evt hand.   "color to replace"
	c _ self rememberedColor ifNil: [Color red].
	self inform: 'now choose the color you want to replace it with'.
	self changeColorTarget: self selector:  #rememberedColor: originalColor: c hand: evt hand.  "new color"
	newC _ self rememberedColor ifNil: [Color blue].
	d _ originalForm depth.
	newForm _ Form extent: originalForm extent depth: d.
	map _ (Color cachedColormapFrom: d to: d) copy.
	map at: (c indexInMap: map) put: (newC pixelValueForDepth: d).
	newForm copyBits: newForm boundingBox
		from: originalForm at: 0@0
		colorMap: map.
	self form: newForm.
