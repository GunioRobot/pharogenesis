step

	"*** hack ***"
	pickedPoint _ nil.
	"*** hack ***"
	myWonderland getEditor isInWorld
		ifTrue:[self changed]
		ifFalse:[(self hasProperty: #keepStepping) ifTrue:[
					self changed.
					myWonderland getScheduler tick]]