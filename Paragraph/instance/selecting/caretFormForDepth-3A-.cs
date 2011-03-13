caretFormForDepth: depth
	"Return a caret form for the given depth."
	"(Paragraph new caretFormForDepth: Display depth) displayOn: Display at: 0@0 rule: Form reverse"

	| box f bb map |
	box := CaretForm boundingBox.
	f := Form extent: box extent depth: depth.
	map := (Color cachedColormapFrom: CaretForm depth to: depth) copy.
	map at: 1 put: (Color transparent pixelValueForDepth: depth).
	map at: 2 put: (Color quickHighLight: depth) first.  "pixel value for reversing"
	bb := BitBlt current toForm: f.
	bb
		sourceForm: CaretForm;
		sourceRect: box;
		destOrigin: 0@0;
		colorMap: map;
 		combinationRule: Form over;
		copyBits.
	^ f