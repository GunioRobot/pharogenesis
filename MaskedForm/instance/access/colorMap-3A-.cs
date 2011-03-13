colorMap: anArray
	"Map the pixelValues in theForm through the colors is this array.  Array should be 2^(theForm depth) long.  If shorter, will be padded.  If longer, truncated.  Map is cached in rawColorMap.  6/28/96 tk"

	| d mapSize |
	anArray == nil ifTrue: ["clear it"
		colorMap _ nil.
		rawColorMap _ nil].	"uncache"
	d _ theForm depth.
	colorMap _ anArray.
	mapSize _ (1 bitShift: d) min: (512 max: anArray size).
		"Want 2^^depth, except where huge, except if big map supplied"
	rawColorMap _ Bitmap new: mapSize.
	colorMap doWithIndex: [:color :ind |
		rawColorMap at: ind put: (color pixelWordForDepth: d)].
		"Note that we don't supply default colors in the added part of the map.  We assume no pixel values are used outside the supplied map." 