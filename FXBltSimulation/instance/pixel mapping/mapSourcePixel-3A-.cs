mapSourcePixel: sourcePixel
	"Expand the given source pixel value into canonical RGBA space."
	| val |
	self inline: true.
	noSourceMap ifTrue:[^sourcePixel].
	sourceMap == nil
		ifTrue:[val _ sourcePixel]
		ifFalse:[val _ sourceMap at: (sourcePixel bitAnd: smMask)].
	(smShiftTable == nil or:[smMaskTable == nil])
		ifTrue:[^val]
		ifFalse:[^self rgbMapPixel: val shifts: smShiftTable masks: smMaskTable].