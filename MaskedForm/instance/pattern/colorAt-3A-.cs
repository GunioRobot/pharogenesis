colorAt: aPoint 
	"Answer the color at the receiver's position aPoint.  If transparent there, return the color being used for transparent.  (Watch out for two colors with the same value). 6/20/96 tk"

	| pix |
	pix _ theForm pixelValueAt: aPoint.
	(mask pixelValueAt: aPoint) = 0 ifTrue: ["transparent"
			pix _ (pix = 0) & (transparentPixelValue ~~ nil)
				ifTrue: [transparentPixelValue]
				ifFalse: [pix]].
	^ Color colorFromPixelValue: pix depth: theForm depth