smoothPix: n atXf: xf yf: yf dxh: dxh dyh: dyh dxv: dxv dyv: dyv
	pixPerWord: srcPixPerWord pixelMask: sourcePixMask
	sourceMap: sourceMap
	| sourcePix r g b x y rgb bitsPerColor d nPix maxPix |
	self inline: false.
	r _ g _ b _ 0.  "Separate r, g, b components"
	maxPix _ n*n.
	x _ xf.  y _ yf.
	nPix _ 0.  "actual number of pixels (not clipped and not transparent)"
	0 to: n-1 do:
		[:i |
		0 to: n-1 do:
			[:j |
			sourcePix _ (self sourcePixAtX: x + (dxh*i) + (dxv*j)  >> BinaryPoint
									y: y + (dyh*i) + (dyv*j)  >> BinaryPoint
									pixPerWord: srcPixPerWord)
									bitAnd: sourcePixMask.
			(combinationRule=25 "PAINT" and: [sourcePix = 0]) ifFalse:  
			["If not clipped and not transparent, then tally rgb values"
			nPix _ nPix + 1.
			sourcePixSize < 16
				ifTrue: ["Get 24-bit RGB values from sourcemap table"
						rgb _ (interpreterProxy fetchWord: sourcePix ofObject: sourceMap) bitAnd: 16rFFFFFF]
				ifFalse: ["Already in RGB format"
						sourcePixSize = 32
						ifTrue: [rgb _ sourcePix bitAnd: 16rFFFFFF]
						ifFalse: ["Note could be faster"
								rgb _ self rgbMap: sourcePix from: 5 to: 8]].
			r _ r + ((rgb >> 16) bitAnd: 16rFF).
			g _ g + ((rgb >> 8) bitAnd: 16rFF).
			b _ b + (rgb bitAnd: 16rFF).
			]].
		].
	(nPix = 0 or: [combinationRule=25 "PAINT" and: [nPix < (maxPix//2)]])
		ifTrue: [^ 0  "All pixels were 0, or most were transparent"].
	colorMap ~= interpreterProxy nilObject
		ifTrue: [bitsPerColor _ cmBitsPerColor]
		ifFalse: [destPixSize = 16 ifTrue: [bitsPerColor _ 5].
				destPixSize = 32 ifTrue: [bitsPerColor _ 8]].
	d _ 8 - bitsPerColor.
	rgb _ ((r // nPix >> d) << (bitsPerColor*2))
		+ ((g // nPix >> d) << bitsPerColor)
		+ ((b // nPix >> d)).
	rgb = 0 ifTrue: [
		"only generate zero if pixel is really transparent"
		(r + g + b) > 0 ifTrue: [rgb _ 1]].
	colorMap ~= interpreterProxy nilObject
		ifTrue: [^ interpreterProxy fetchWord: rgb ofObject: colorMap]
		ifFalse: [^ rgb]
