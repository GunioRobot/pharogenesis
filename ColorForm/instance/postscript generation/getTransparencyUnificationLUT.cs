getTransparencyUnificationLUT
	| lut transparentIndex |
	lut _ Array new:colors size.
	transparentIndex _ self indexOfColor:Color transparent.
	1 to: colors size do:
		[ :i | lut at:i put:(((colors at:i) = Color transparent) ifTrue:[transparentIndex] ifFalse:[i])].
 