clearViewport: aColor
	| cc |
	cc _ aColor asColor.
	self primRender: handle 
			clearViewport: (cc pixelWordForDepth: 32)
			with: 0 "(target pixelWordFor: cc)".