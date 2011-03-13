pixelValueAt: aPoint put: pixelValue
	"Store the pixel value at coordinate aPoint.  Use colorAt:put: instead. 6/20/96 tk"

	^ (BitBlt bitPokerToForm: self) pixelAt: aPoint put: pixelValue