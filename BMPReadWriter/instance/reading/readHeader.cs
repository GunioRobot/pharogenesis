readHeader
	| reserved |
	bfType _ stream nextLittleEndianNumber: 2.
	bfSize _ stream nextLittleEndianNumber: 4.
	reserved _ stream nextLittleEndianNumber: 4.
	bfOffBits _ stream nextLittleEndianNumber: 4.
	biSize _ stream nextLittleEndianNumber: 4.
	biWidth _ stream nextLittleEndianNumber: 4.
	biHeight _ stream nextLittleEndianNumber: 4.
	biPlanes _ stream nextLittleEndianNumber: 2.
	biBitCount _ stream nextLittleEndianNumber: 2.
	biCompression _ stream nextLittleEndianNumber: 4.
	biSizeImage _ stream nextLittleEndianNumber: 4.
	biXPelsPerMeter _ stream nextLittleEndianNumber: 4.
	biYPelsPerMeter _ stream nextLittleEndianNumber: 4.
	biClrUsed _ stream nextLittleEndianNumber: 4.
	biClrImportant _ stream nextLittleEndianNumber: 4.
