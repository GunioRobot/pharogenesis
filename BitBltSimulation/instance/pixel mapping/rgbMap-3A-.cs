rgbMap: sourcePixel
	"Color map the given source pixel.
	Note: This relies on an accurate setup of the cmShifts and cmMasks
	by BitBlt and can therefore not be used from WarpBlt in smoothing
	mode (but hey, then we have to go over lots of different pixels
	before we even come to the output color conversion so that doesn't
	really matter)."
	self inline: true. "you bet"
	cmDeltaBits < 0 "Compress or expand RGB values?!"
		ifTrue:[^((sourcePixel bitAnd: cmRedMask) >> cmRedShift) bitOr:
					(((sourcePixel bitAnd: cmGreenMask) >> cmGreenShift) bitOr:
						((sourcePixel bitAnd: cmBlueMask) >> cmBlueShift))]
		ifFalse:[^((sourcePixel bitAnd: cmRedMask) << cmRedShift) bitOr:
					(((sourcePixel bitAnd: cmGreenMask) << cmGreenShift) bitOr:
						((sourcePixel bitAnd: cmBlueMask) << cmBlueShift))]