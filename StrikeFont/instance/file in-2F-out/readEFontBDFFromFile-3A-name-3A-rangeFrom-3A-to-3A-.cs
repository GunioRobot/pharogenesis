readEFontBDFFromFile: fileName name: aString rangeFrom: startRange to: endRange

	| fontReader stream |
	fontReader _ EFontBDFFontReader readOnlyFileNamed: fileName.
	stream _ ReadStream on: (fontReader readFrom: startRange to: endRange).
	xTable _ stream next.
	glyphs _ stream next.
	minAscii _ stream next.
	maxAscii _ stream next.
	maxWidth _ stream next.
	ascent _ stream next.
	descent _ stream next.
	pointSize _ stream next.
	name _ aString.
	type _ 0. "no one see this"
	superscript _ ascent - descent // 3.	
	subscript _ descent - ascent // 3.	
	emphasis _ 0.
	self reset.
