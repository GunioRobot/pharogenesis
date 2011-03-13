pixelValueAt: aPoint 
	"Answer the value at the receiver's position aPoint.  Adjust so transparent value is correct. 6/20/96 tk"

	| pix |
	pix _ theForm pixelValueAt: aPoint.
	(mask pixelValueAt: aPoint) = 0 ifTrue: ["transparent"
		^ (pix = 0) & (transparentPixelValue ~~ nil)
				ifTrue: [transparentPixelValue]
				ifFalse: [pix]].
	^ pix