pixelValueAt: aPoint put: newVal
	"Store the value at the receiver's position aPoint.  Assumed to be opaque (so correct color will show) unless it is the values used for transparent. 6/20/96 tk"

newVal = transparentPixelValue 
	ifTrue: [theForm pixelValueAt: aPoint put: 0.
		mask pixelValueAt: aPoint put: 0]
	ifFalse: [theForm pixelValueAt: aPoint put: newVal.
		mask pixelValueAt: aPoint put: 1].
^ newVal