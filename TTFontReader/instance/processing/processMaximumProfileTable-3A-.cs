processMaximumProfileTable: entry
"
numGlyphs         USHORT      The number of glyphs in the font.
"
	entry skip: 4. "Skip Table version number"
	nGlyphs _ entry nextUShort.