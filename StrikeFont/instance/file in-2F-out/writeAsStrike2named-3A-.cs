writeAsStrike2named: fileName
	"Write me onto a file in strike2 format.
	fileName should be of the form: <family name><pointSize>.sf2"

	| file |
	file _ FileStream fileNamed: fileName.
	file binary.
	[file nextInt32Put: 2. "type"
	file nextInt32Put: minAscii.
	file nextInt32Put: maxAscii.
	file nextInt32Put: maxWidth.
	file nextInt32Put: ascent.
	file nextInt32Put: descent.
	file nextInt32Put: pointSize.
	superscript _ ascent - descent // 3.	
	subscript _ descent - ascent // 3.	
	file nextInt32Put: emphasis.
	(minAscii + 1 to: maxAscii + 3) do: [:index | file nextInt32Put: (xTable at: index)].
	glyphs writeOn: file] ensure: [file close]