brushAlphaFromGray
	"Get currentNib again, (a gray-scale Form) and transform it into an alpha brush.  3/15/97 tk"

	| d alphaMap this alpha colorMaker newBox smallNib |
	currentNib _ palette getNib.
	newBox _ currentNib rectangleEnclosingPixelsNotOfColor: Color transparent.
	"minimum size"
	smallNib _ Form extent: newBox extent depth: currentNib depth.
	smallNib copyBits: newBox from: currentNib at: 0@0 
		clippingBox: smallNib boundingBox rule: Form over fillColor: nil.
"smallNib display.  newBox printString displayAt: 0@50."

	d _ currentNib depth.	"usually 8"
	alphaMap _ (Color cachedColormapFrom: d to: 32) copy.	"force a map to be there"
	1 to: alphaMap size do: [:pixVal |
		this _ Color colorFromPixelValue: pixVal-1 depth: d.
		alpha _ 1.0 - this brightness.	"based on brightness"
		"alpha _ alpha * 0.14 - 0.01."	"Adjust sensitivity for buffer depth"
		"alpha _ alpha raisedTo: 2.0."	"Adjust sensitivity for buffer depth"
		alphaMap at: pixVal 
				put: ((currentColor alpha: alpha) pixelWordForDepth: 32)].	
	brush _ Form extent: smallNib extent depth: 32.
	"brush offset: smallNib offset."
	colorMaker _ BitBlt current toForm: brush.
	colorMaker sourceForm: smallNib; colorMap: alphaMap.
	colorMaker sourceOrigin: 0@0; destOrigin: 0@0; combinationRule: Form over;
		width: brush width; height: brush height; copyBits.
	^ brush
	