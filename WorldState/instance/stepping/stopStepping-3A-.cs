stopStepping: aMorph
	"Remove the given morph from the step list."
	lastStepMessage ifNotNil:[
		(lastStepMessage receiver == aMorph) ifTrue:[lastStepMessage _ nil]].
	stepList removeAll: (stepList select:[:stepMsg| stepMsg receiver == aMorph]).
