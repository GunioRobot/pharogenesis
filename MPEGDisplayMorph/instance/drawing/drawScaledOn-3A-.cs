drawScaledOn: aCanvas
	"Draw the current frame image scaled to my bounds."

	| outForm destPoint warpBlt |
	((aCanvas isKindOf: FormCanvas) and: [aCanvas form = Display])
		ifTrue: [  "optimization: when canvas is the Display, Warpblt directly to it"
			outForm _ Display.
			destPoint _ bounds origin + aCanvas origin]
		ifFalse: [
			outForm _ Form extent: self extent depth: aCanvas form depth.
			destPoint _ 0@0].
	warpBlt _ (WarpBlt current toForm: outForm)
		sourceForm: frameBuffer;
		colorMap: (frameBuffer colormapIfNeededForDepth: outForm depth);
		cellSize: 1;  "installs a new colormap if cellSize > 1"
		combinationRule: Form over.
	outForm == Display ifTrue: [warpBlt clipRect: aCanvas clipRect].
	warpBlt
		copyQuad: frameBuffer boundingBox innerCorners
		toRect: (destPoint extent: self extent).
	outForm == Display ifFalse: [
		aCanvas drawImage: outForm at: bounds origin].

