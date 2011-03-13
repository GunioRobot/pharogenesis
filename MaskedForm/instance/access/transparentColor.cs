transparentColor
	"Return the color that is being used as transparent.  Not all pixels with this color are transparent if there is more than one internal pixelValue for this color.  6/21/96 tk"

	transparentPixelValue == nil ifTrue: [^ nil].
	^ Color colorFromPixelValue: transparentPixelValue depth: theForm depth