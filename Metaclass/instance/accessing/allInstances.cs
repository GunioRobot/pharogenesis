allInstances
	thisClass class == self ifTrue:[^Array with: thisClass].
	^super allInstances