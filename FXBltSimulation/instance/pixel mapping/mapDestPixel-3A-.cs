mapDestPixel: destPixel
	"Expand the given destination pixel value into canonical RGBA space."
	| val |
	self inline: true.
	noDestMap ifTrue:[^destPixel].
	destMap == nil
		ifTrue:[val _ destPixel]
		ifFalse:[val _ destMap at: (destPixel bitAnd: dmMask)].
	(dmShiftTable == nil or:[dmMaskTable == nil])
		ifTrue:[^val]
		ifFalse:[^self rgbMapPixel: val shifts: dmShiftTable masks: dmMaskTable].