readFrom: fontData fromOffset: offset at: encodingTag

	| headerEntry maxProfileEntry nameEntry indexLocEntry charMapEntry glyphEntry horzHeaderEntry horzMetricsEntry kerningEntry glyphOffset cmap numHMetrics indexToLocFormat fontDescription0 fontDescription1 array result |

	"Search the tables required to build the font"
	(headerEntry _ self getTableDirEntry: 'head' from: fontData offset: offset) == nil ifTrue:[
		^self error:'This font does not have a header table'].
	(maxProfileEntry _ self getTableDirEntry: 'maxp' from: fontData offset: offset) == nil ifTrue:[
		^self error:'This font does not have a maximum profile table'].
	(nameEntry _ self getTableDirEntry: 'name' from: fontData offset: offset) == nil ifTrue:[
		^self error:'This font does not have a name table'].
	(indexLocEntry _ self getTableDirEntry: 'loca' from: fontData offset: offset) == nil ifTrue:[
		^self error:'This font does not have a relocation table'].
	(charMapEntry _ self getTableDirEntry: 'cmap' from: fontData offset: offset) == nil ifTrue:[
		^self error:'This font does not have a character map table'].
	(glyphEntry _ self getTableDirEntry: 'glyf' from: fontData  offset: offset) == nil ifTrue:[
		^self error:'This font does not have a glyph table'].
	(horzHeaderEntry _ self getTableDirEntry: 'hhea' from: fontData offset: offset) == nil ifTrue:[
		^self error:'This font does not have a horizontal header table'].
	(horzMetricsEntry _ self getTableDirEntry: 'hmtx' from: fontData offset: offset) == nil ifTrue:[
		^self error:'This font does not have a horizontal metrics table'].
	(kerningEntry _ self getTableDirEntry: 'kern' from: fontData offset: offset) == nil ifTrue:[
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
	array _ self processCharMap: cmap.
	fontDescription0 _ fontDescription clone.
	fontDescription1 _ fontDescription clone.
	fontDescription0 setGlyphs: (array at: 1) mapping: nil.
	fontDescription1 setGlyphs: (array at: 2) mapping: nil.
	"fontDescription setKernPairs: kernPairs."
	result _ OrderedCollection new.
	(encodingTag = nil or: [encodingTag = 0]) ifTrue: [^ Array with: fontDescription1].
	result add: fontDescription0.
	encodingTag -1 timesRepeat: [result add: nil].
	result add: fontDescription1.
	^ result asArray.

