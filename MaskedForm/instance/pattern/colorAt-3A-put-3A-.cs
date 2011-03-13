colorAt: aPoint put: aColor
	"Store the color at the receiver's position aPoint.  Assumed to be opaque (so correct color will show) unless it is the value used for transparent. 6/22/96 tk"

	^ self pixelValueAt: aPoint 
		put: (aColor pixelValueForDepth: theForm depth)
