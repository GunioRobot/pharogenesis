intStepToNextScanLineAt: yValue in: edgeTableEntry
	"Scaled integer version of forward differencing"
	[maxSteps >= 0 and:[yValue * 256 > lastY]] whileTrue:[
		self validateIntegerRange.
		lastX _ lastX + ((fwDx + 16r8000) // 16r10000).
		lastY _ lastY + ((fwDy + 16r8000) // 16r10000).
		fwDx _ fwDx + fwDDx.
		fwDy _ fwDy + fwDDy.
		maxSteps _ maxSteps - 1.
	].
	edgeTableEntry xValue: lastX // 256.
	edgeTableEntry zValue: 0.