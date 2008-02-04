setFont
	foregroundColor ifNil: [foregroundColor := Color black].
	super setFont.
	baselineY := lineY + line baseline.
	destY := baselineY - font ascent.