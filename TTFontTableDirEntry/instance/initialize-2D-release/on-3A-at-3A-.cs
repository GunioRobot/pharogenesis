on: fd at: index

	fontData _ fd.
	tag _ fontData longAt: index bigEndian: true.
	checkSum _ fontData longAt: index+4 bigEndian: true.
	offset _ (fontData longAt: index+8 bigEndian: true) + 1.
	length _ fontData longAt: index+12 bigEndian: true.