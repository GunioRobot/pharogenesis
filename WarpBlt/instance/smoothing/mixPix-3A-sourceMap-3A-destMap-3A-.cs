mixPix: pix sourceMap: sourceMap destMap: destMap
	"Average the pixels in array pix to produce a destination pixel.
	First average the RGB values either from the pixels directly,
	or as supplied in the sourceMap.  Then return either the resulting
	RGB value directly, or use it to index the destination color map." 
	| r g b rgb nPix bitsPerColor d |
	nPix _ pix size.
	r _ 0. g _ 0. b _ 0.
	1 to: nPix do:
		[:i |   "Sum R, G, B values for each pixel"
		rgb _ sourceForm depth <= 8
				ifTrue: [sourceMap at: (pix at: i) + 1]
				ifFalse: [sourceForm depth = 32
						ifTrue: [pix at: i]
						ifFalse: [self rgbMap: (pix at: i) from: 5 to: 8]].
		r _ r + ((rgb bitShift: -16) bitAnd: 16rFF).
		g _ g + ((rgb bitShift: -8) bitAnd: 16rFF).
		b _ b + ((rgb bitShift: 0) bitAnd: 16rFF)].
	destMap == nil
		ifTrue: [bitsPerColor _ 3.  "just in case eg depth <= 8 and no map"
				destForm depth = 16 ifTrue: [bitsPerColor _ 5].
				destForm depth = 32 ifTrue: [bitsPerColor _ 8]]
		ifFalse: [destMap size = 512 ifTrue: [bitsPerColor _ 3].
				destMap size = 4096 ifTrue: [bitsPerColor _ 4].
				destMap size = 32768 ifTrue: [bitsPerColor _ 5]].
	d _ bitsPerColor - 8.
	rgb _ ((r // nPix bitShift: d) bitShift: bitsPerColor*2)
		+ ((g // nPix bitShift: d) bitShift: bitsPerColor)
		+ ((b // nPix bitShift: d) bitShift: 0).
	destMap == nil
		ifTrue: [^ rgb]
		ifFalse: [^ destMap at: rgb+1]