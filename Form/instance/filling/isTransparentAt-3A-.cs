isTransparentAt: aPoint 
	"Return true if the receiver is transparent at the given point."

	depth = 1 ifTrue: [^ false].  "no transparency at depth 1"
	^ (self pixelValueAt: aPoint) = (Color transparent pixelValueForDepth: depth)
