processHorizontalHeaderTable: entry
"
ascender           SHORT          Typographic ascent.
descender          SHORT          Typographic descent.
lineGap            SHORT          Typographic lineGap.
numberOfHMetrics   USHORT         Number hMetric entries in the HTMX
                                               Table; may be smaller than the total
                                             number of glyphs.
"
	| asc desc lGap numHMetrics |
	entry skip: 4. "Skip table version"
	asc _ entry nextShort.
	desc _ entry nextShort.
	lGap _ entry nextShort.
	entry skip: 2. "Skip advanceWidthMax"
	entry skip: 2. "Skip minLeftSideBearing"
	entry skip: 2. "Skip minRightSideBearing"
	entry skip: 2. "Skip xMaxExtent"
	entry skip: 2. "Skip caretSlopeRise"
	entry skip: 2. "Skip caretSlopeRun"
	entry skip: 10. "Skip 5 reserved shorts"
	entry skip: 2. "Skip metricDataFormat"

	numHMetrics _ entry nextUShort.

	fontDescription setAscender: asc descender: desc lineGap: lGap.
	^numHMetrics