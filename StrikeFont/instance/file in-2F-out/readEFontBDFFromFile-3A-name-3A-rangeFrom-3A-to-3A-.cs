readEFontBDFFromFile: fileName name: aString rangeFrom: startRange to: endRange 
	| fontReader stream |
	fontReader := EFontBDFFontReader readOnlyFileNamed: fileName.
	stream := (fontReader 
		readFrom: startRange
		to: endRange) readStream.
	xTable := stream next.
	glyphs := stream next.
	minAscii := stream next.
	maxAscii := stream next.
	maxWidth := stream next.
	ascent := stream next.
	descent := stream next.
	pointSize := stream next.
	name := aString.
	type := 0.	"no one see this"
	superscript := (ascent - descent) // 3.
	subscript := (descent - ascent) // 3.
	emphasis := 0.
	self reset