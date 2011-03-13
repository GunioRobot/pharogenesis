writeHeader

	| byte |
	self nextPutAll: 'GIF87a' asByteArray.
	self writeWord: width.	"Screen Width"
	self writeWord: height.	"Screen Height"
	byte _ 16r80.  "has color map"
	byte _ byte bitOr: ((bitsPerPixel - 1) bitShift: 5).  "color resolution"
	byte _ byte bitOr: bitsPerPixel - 1.  "bits per pixel"
	self nextPut: byte.
	self nextPut: 0.		"background color."
	self nextPut: 0.		"reserved"
	colorPalette do: [:pixelValue |
		self	nextPut: ((pixelValue bitShift: -16) bitAnd: 255);
			nextPut: ((pixelValue bitShift: -8) bitAnd: 255);
			nextPut: (pixelValue bitAnd: 255)].

	transparentIndex ifNotNil: [
		"write graphics control block to record transparent color index"
		self
			nextPut: Extension;
			nextPutAll: (#(16rF9 4 1 0 0) as: ByteArray);
			nextPut: transparentIndex;
			nextPut: 0].

	self nextPut: ImageSeparator.
	self writeWord: 0.		"Image Left"
	self writeWord: 0.		"Image Top"
	self writeWord: width.	"Image Width"
	self writeWord: height.	"Image Height"
	byte _ interlace ifTrue: [16r40] ifFalse: [0].
	self nextPut: byte.
