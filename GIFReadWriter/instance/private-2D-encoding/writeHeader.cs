writeHeader
	| byte |
	self nextPutAll: 'GIF87a' asByteArray.
	self writeWord: width.		"Screen Width"
	self writeWord: height.	"Screen Height"
	byte _ 16r80.			"has color map"
	byte _ byte bitOr: ((bitsPerPixel - 1) bitShift: 5).	"color
resolution"
	byte _ byte bitOr: bitsPerPixel - 1.
	self nextPut: byte.	"bits per pixel"
	self nextPut: 0.		"background color."
	self nextPut: 0.		"null (future expansion)"
	colorPalette do: [:c |
		self nextPut: (c privateRed bitShift: -2);
			nextPut: (c privateGreen bitShift: -2);
			nextPut: (c privateBlue bitShift: -2)].
	"	self nextPut: ((c red * 255.0) asInteger bitAnd: 255);
	less accurate and slower
			nextPut: ((c green * 255.0) asInteger bitAnd: 255);
			nextPut: ((c blue * 255.0) asInteger bitAnd: 255)].
	"
	colorPalette size + 1 to: (1 bitShift: bitsPerPixel) do: [:i |
		self nextPut: 0; nextPut: 0; nextPut: 0].
	self nextPut: ImageSeparator.
	self writeWord: 0.		"Image Left"
	self writeWord: 0.		"Image Top"
	self writeWord: width.		"Image Width"
	self writeWord: height.	"Image Height"
	byte _ interlace ifTrue: [16r40] ifFalse: [0].
	self nextPut: byte