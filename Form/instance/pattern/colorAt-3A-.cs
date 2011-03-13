colorAt: aPoint
	"Return the Color in the pixel at coordinate aPoint.  6/20/96 tk"

	^ Color 
		colorFromPixelValue: 
			((BitBlt bitPokerToForm: self) pixelAt: aPoint)
		depth: depth