transformBy: aDisplayTransform clippingTo: aClipRect during: aBlock smoothing: cellSize
	| newCanvas |

	self flag: #bob.		"do tranform and clip work together properly?"
	newCanvas := RemoteCanvas 
		connection: connection 
		clipRect: (aClipRect intersect: outerClipRect)
		transform: (transform composedWith: aDisplayTransform).
	aBlock value: newCanvas.