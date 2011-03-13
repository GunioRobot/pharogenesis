readEFontBDFForJapaneseFromFile: fileName name: aString overrideWith: otherFileName 
	| fontReader stream |
	fontReader := EFontBDFFontReaderForRanges readOnlyFileNamed: fileName.
	stream := (fontReader 
		readRanges: fontReader rangesForJapanese
		overrideWith: otherFileName
		otherRanges: {  (Array  with: 8481 with: 12320)  }
		additionalOverrideRange: fontReader additionalRangesForJapanese) readStream.
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