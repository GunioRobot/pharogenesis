floatStepToNextScanLineAt: yValue in: edgeTableEntry
	"Float version of forward differencing"
	[yValue asFloat > lastY] whileTrue:[
		(fwDx < -50.0 or:[fwDx > 50.0]) ifTrue:[self halt].
		(fwDy < -50.0 or:[fwDy > 50.0]) ifTrue:[self halt].
		(fwDDx < -50.0 or:[fwDDx > 50.0]) ifTrue:[self halt].
		(fwDDy < -50.0 or:[fwDDy > 50.0]) ifTrue:[self halt].
		lastX _ lastX + fwDx.
		lastY _ lastY + fwDy.
		fwDx _ fwDx + fwDDx.
		fwDy _ fwDy + fwDDy.
	].
	edgeTableEntry xValue: lastX asInteger.
	edgeTableEntry zValue: 0.