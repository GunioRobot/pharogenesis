pickSourcePixels: nPix nullMap: nullMap srcMask: sourcePixMask destMask: destPixMask
	"This is intended to be expanded in-line; it merely calls the others"
	self inline: true.
	sourcePixSize >= 16 ifTrue:
		[^ self pickSourcePixelsRGB: nPix nullMap: nullMap srcMask: sourcePixMask destMask: destPixMask].
	nullMap ifTrue:
		[^ self pickSourcePixelsNullMap: nPix srcMask: sourcePixMask destMask: destPixMask].
	^ self pickSourcePixels: nPix srcMask: sourcePixMask destMask: destPixMask