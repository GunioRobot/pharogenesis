mapPixel: sourcePixel
	"Color map the given source pixel."
	| pv |
	self inline: true.
	noColorMap ifTrue:[^sourcePixel].
	(cmMaskTable == nil or:[cmShiftTable == nil])
		ifTrue:[pv _ sourcePixel]
		ifFalse:[pv _ self rgbMapPixel: sourcePixel shifts: cmShiftTable masks: cmMaskTable].
	colorMap == nil
		ifTrue:[^pv]
		ifFalse:[^colorMap at: (pv bitAnd: cmMask)]