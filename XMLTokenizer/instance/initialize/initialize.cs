initialize
	parsingMarkup _ false.
	validating _ false.
	attributeBuffer _ WriteStream on: (String new: 128).
	nameBuffer _ WriteStream on: (String new: 128)