setShifts: shiftArray masks: maskArray colors: colorArray
	shiftArray ifNotNil:[shifts _ shiftArray asIntegerArray].
	maskArray ifNotNil:[masks _ maskArray asWordArray].
	colorArray ifNotNil:[colors _ colorArray asWordArray].