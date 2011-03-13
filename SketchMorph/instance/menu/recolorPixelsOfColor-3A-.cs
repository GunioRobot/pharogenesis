recolorPixelsOfColor: evt
	"Let the user select a color to be remapped, and then a color to map that color to, then carry it out."

	| c d newForm map newC |
	self inform: 'choose the color you want to replace' translated.
	self changeColorTarget: self selector: #rememberedColor: originalColor: nil hand: evt hand.   "color to replace"
	c := self rememberedColor ifNil: [Color red].
	self inform: 'now choose the color you want to replace it with' translated.
	self changeColorTarget: self selector:  #rememberedColor: originalColor: c hand: evt hand.  "new color"
	newC := self rememberedColor ifNil: [Color blue].
	d := originalForm depth.
	newForm := Form extent: originalForm extent depth: d.
	map := (Color cachedColormapFrom: d to: d) copy.
	map at: (c indexInMap: map) put: (newC pixelValueForDepth: d).
	newForm copyBits: newForm boundingBox
		from: originalForm at: 0@0
		colorMap: map.
	self form: newForm.
