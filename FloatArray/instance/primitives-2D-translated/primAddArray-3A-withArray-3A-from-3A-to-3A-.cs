primAddArray: floatArray1 withArray: floatArray2 from: firstIndex to: lastIndex
	| length stop start srcIndex |
	<primitive: 'primitiveFloatArrayAddFloatArrayFromTo' module: 'sqPlugin'>
	self var: #floatArray1 declareC:'float *floatArray1'.
	self var: #floatArray2 declareC:'float *floatArray2'.
	length _ floatArray1 size.
	start _ firstIndex.
	stop _ length min: lastIndex.
	length _ floatArray2 size.
	(stop - start + 1) > length ifTrue:[stop _ start + length - 1].
	srcIndex _ 1.
	start to: stop do:[:dstIndex|
		floatArray1 at: dstIndex put: (floatArray1 at: dstIndex) + (floatArray2 at: srcIndex).
		srcIndex _ srcIndex+1].