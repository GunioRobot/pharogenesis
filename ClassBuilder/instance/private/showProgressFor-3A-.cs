showProgressFor: aClass
	"Announce that we're processing aClass"
	progress == nil ifTrue:[^self].
	currentClassIndex _ currentClassIndex + 1.
	aClass hasMethods ifTrue:[
		progress value: ('Recompiling ', aClass name,' (', currentClassIndex printString,'/', maxClassIndex printString,')')].