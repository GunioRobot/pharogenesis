readMacFontHex: fileName
	"Read the hex version of a Mac FONT type resource.  See the method aComment for how to prepare the input file. 4/26/96 tk"
	| file hh fRectWidth |
	name _ fileName.	"Palatino 12"
	file _ FileStream readOnlyFileNamed: fileName, ' hex'.

	"See Inside Macintosh page IV-42 for this record"
	"FontType _ " Number readFrom: (file next: 4) base: 16.
	emphasis		_		0.
	minAscii _ Number readFrom: (file next: 4) base: 16.
	maxAscii _ Number readFrom: (file next: 4) base: 16.
	maxWidth		_ Number readFrom: (file next: 4) base: 16.
	"kernMax _ " Number readFrom: (file next: 4) base: 16.
	"NDescent _ " Number readFrom: (file next: 4) base: 16.
	fRectWidth _  Number readFrom: (file next: 4) base: 16.
	hh _  Number readFrom: (file next: 4) base: 16.
	"OWTLoc _ " Number readFrom: (file next: 4) base: 16.
	ascent			_ Number readFrom: (file next: 4) base: 16.
	descent			_ Number readFrom: (file next: 4) base: 16.
	"leading _ " Number readFrom: (file next: 4) base: 16.
	xOffset			_		0. 	
	raster			_ Number readFrom: (file next: 4) base: 16.

	strikeLength	_		raster*16.
	superscript		_		ascent - descent // 3.	
	subscript		_		descent - ascent // 3.	
	self strikeFromHex: file width: raster height: hh.
	self xTableFromHex: file.
	file close.

	"Insert one pixel between each character.  And add space character."
	self fixKerning: (fRectWidth - maxWidth).	

	"Recompute character to glyph mapping"
	characterToGlyphMap _ nil.