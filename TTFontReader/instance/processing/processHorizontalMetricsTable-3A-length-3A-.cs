processHorizontalMetricsTable: entry length: numHMetrics
	"Extract the advance width, left side bearing, and right
	side bearing for each glyph from the Horizontal Metrics Table."
	|  index lastAW glyph |
	index _ 1.
	[index <= numHMetrics] whileTrue:[
		glyph _ glyphs at: index.
		glyph advanceWidth: entry nextUShort.
		glyph leftSideBearing: entry nextShort.
		glyph updateRightSideBearing.
		index _ index + 1].
	index = (nGlyphs +1) ifTrue:[^true].
	lastAW _ (glyphs at: index-1) advanceWidth.

	[index <= nGlyphs] whileTrue:[
		glyph _ glyphs at: index.
		glyph advanceWidth: lastAW.
		glyph leftSideBearing: entry nextShort.
		glyph updateRightSideBearing.
		index _ index + 1].