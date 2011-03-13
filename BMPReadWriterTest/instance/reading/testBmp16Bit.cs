testBmp16Bit
	| reader form |
	reader := BMPReadWriter new on: (ReadStream on: self bmpData16bit).
	form := reader nextImage.
	"special black here to compensate for zero-is-transparent effect"
	self assert: (form colorAt: 7@1) = Color red.
	self assert: (form colorAt: 1@7) = Color green.
	self assert: (form colorAt: 7@7) = Color blue.
	self assert: (form colorAt: 4@4) = Color white.
	self assert: (form pixelValueAt: 1@1) = 16r8000.
