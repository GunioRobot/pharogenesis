testBitmapByteAt
	| bm |
	bm := Bitmap new: 1.
	1 to: 4 do:[:i|
		self should:[bm byteAt: i put: 1000] raise: Error.
	].