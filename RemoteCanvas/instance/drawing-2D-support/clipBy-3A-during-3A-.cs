clipBy: aRectangle during: aBlock
	| newCanvas newR |
	"Set a clipping rectangle active only during the execution of aBlock."

	newR _ transform localBoundsToGlobal: aRectangle.

	newCanvas _ RemoteCanvas 
		connection: connection 
		clipRect: (outerClipRect intersect: newR) 
		transform: transform.
	newCanvas privateShadowColor: shadowColor.
	aBlock value: newCanvas.
	connection shadowColor: shadowColor.