transBrushPrep
	"Prepare to paint with a transparent brush at twice the resolution.  Do the work in 32-bits.  See BitBlt.alphaBlendDemo8 for details.  "

	| buffSize scale cm1 cm2 |
	currentColor class == Bitmap ifTrue: [currentColor _ palette getColor]. "do not force white"
	brush _ self brushAlphaFromGray.	"Get currentNib again, 
		(a gray-scale Form) and transform it into an alpha brush"
	scale _ 3.  "Actual drawing happens at this magnification"
	"Scale brush up for painting in magnified buffer"
	brush _ brush magnify: brush boundingBox by: scale.

	buffSize _ 100.
	buff _ Form extent: (buffSize * scale) asPoint + brush extent depth: 32.  "Travelling 32-bit buffer"
	picToBuff _ (WarpBlt current toForm: buff)  "from Picture to buff - magnify by 2"
		sourceForm: paintingForm;
		combinationRule: Form over.
	cm1 _ (Color cachedColormapFrom: paintingForm depth to: 32) copy.
	cm1 ifNotNil: [
		"map off-the-edge pixels to the background color, so blend will look right at edge"
		cm1 at: 1 put: (self world color pixelValueForDepth: 32)].
	picToBuff colorMap: cm1.

	brushToBuff _ (BitBlt current toForm: buff)  "from brush to buff"
		sourceForm: brush;
		sourceOrigin: 0@0;
		combinationRule: Form blend.

	"use buffToPic instead of paintingFormPen"
	buffToPic _ (WarpBlt current toForm: paintingForm)  "from buff to Picture - shrink by 2"
		sourceForm: buff;
		cellSize: scale;    "...and use smoothing"
		combinationRule: Form over.
	cm2 _ (Color cachedColormapFrom: 32 to: paintingForm depth) copy.
	cm2 ifNotNil: [
		"remap background color to transparent"
		cm2 at: (self world color indexInMap: cm2) put: 0].
	buffToPic colorMap: cm2.

	buffToBuff _ BitBlt current toForm: buff.  "for slewing the buffer"
