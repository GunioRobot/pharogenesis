readFrom: aStream

	| fontData headerEntry maxProfileEntry nameEntry indexLocEntry charMapEntry glyphEntry horzHeaderEntry horzMetricsEntry kerningEntry glyphOffset cmap numHMetrics indexToLocFormat |

	"Read the raw font byte data"
	(aStream respondsTo: #binary) ifTrue:[aStream binary].
	fontData _ aStream contents asByteArray.
	fontDescription _ TTFontDescription new.

	"Search the tables required to build the font"
	(headerEntry _ self getTableDirEntry: 'head' from: fontData) == nil ifTrue:[
		^self error:'This font does not have a header table'].
	(maxProfileEntry _ self getTableDirEntry: 'maxp' from: fontData) == nil ifTrue:[
		^self error:'This font does not have a maximum profile table'].
	(nameEntry _ self getTableDirEntry: 'name' from: fontData) == nil ifTrue:[
		^self error:'This font does not have a name table'].
	(indexLocEntry _ self getTableDirEntry: 'loca' from: fontData) == nil ifTrue:[
		^self error:'This font does not have a relocation table'].
	(charMapEntry _ self getTableDirEntry: 'cmap' from: fontData) == nil ifTrue:[
		^self error:'This font does not have a character map table'].
	(glyphEntry _ self getTableDirEntry: 'glyf' from: fontData) == nil ifTrue:[
		^self error:'This font does not have a glyph table'].
	(horzHeaderEntry _ self getTableDirEntry: 'hhea' from: fontData) == nil ifTrue:[
		^self error:'This font does not have a horizontal header table'].
	(horzMetricsEntry _ self getTableDirEntry: 'hmtx' from: fontData) == nil ifTrue:[
		^self error:'This font does not have a horizontal metrics table'].
	(kerningEntry _ self getTableDirEntry: 'kern' from: fontData) == nil ifTrue:[
		Transcript cr; show:'This font does not have a kerning table';endEntry].


	"Process the data"
	indexToLocFormat _ self processFontHeaderTable: headerEntry.
	self processMaximumProfileTable: maxProfileEntry.
	self processNamingTable: nameEntry.
	glyphOffset _ self processIndexToLocationTable: indexLocEntry format: indexToLocFormat.
	cmap _ self processCharacterMappingTable: charMapEntry.
	(cmap == nil or:[cmap value == nil])
		ifTrue:[^self error:'This font has no suitable character mappings'].
	self processGlyphDataTable: glyphEntry offsets: glyphOffset.
	numHMetrics _ self processHorizontalHeaderTable: horzHeaderEntry.
	self processHorizontalMetricsTable: horzMetricsEntry length: numHMetrics.
	kerningEntry isNil 
		ifTrue:[kernPairs _ #()]
		ifFalse:[self processKerningTable: kerningEntry].
	charMap _ self processCharMap: cmap.
	fontDescription setGlyphs: glyphs mapping: charMap.
	fontDescription setKernPairs: kernPairs.
	^fontDescription