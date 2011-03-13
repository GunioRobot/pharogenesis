showProgressFor: aClass
	"Announce that we're processing aClass"
	progress == nil ifTrue:[^self].
	currentClassIndex _ currentClassIndex + 1.
	(aClass hasMethods and: [aClass wantsRecompilationProgressReported]) ifTrue:
		[progress value: ('Recompiling ', aClass name,' (', currentClassIndex printString,'/', maxClassIndex printString,')')]