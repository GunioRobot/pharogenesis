setFont
	foregroundColor ifNil: [foregroundColor _ Color black].
	super setFont.
	baselineY _ lineY + line baseline.
	destY _ baselineY - font ascent.