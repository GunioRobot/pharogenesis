rgbMapPixel: sourcePixel flags: mapperFlags
	"Perform the RGBA conversion for the given source pixel"
	| val |
	self inline: true.
	val _ 			((sourcePixel bitAnd: (cmMaskTable at: 0)) bitShift: (cmShiftTable at: 0)).
	val _ val bitOr: ((sourcePixel bitAnd: (cmMaskTable at: 1)) bitShift: (cmShiftTable at: 1)).
	val _ val bitOr: ((sourcePixel bitAnd: (cmMaskTable at: 2)) bitShift: (cmShiftTable at: 2)).
		  ^val bitOr: ((sourcePixel bitAnd: (cmMaskTable at: 3)) bitShift: (cmShiftTable at: 3)).
