stepToNextInt
	"Scaled integer version of forward differencing"
	self halt.
	(maxSteps >= 0) ifTrue:[
		self validateIntegerRange.
		lastX _ lastX + ((fwDx + 16r8000) // 16r10000).
		lastY _ lastY + ((fwDy + 16r8000) // 16r10000).
		fwDx _ fwDx + fwDDx.
		fwDy _ fwDy + fwDDy.
		maxSteps _ maxSteps - 1.
	].