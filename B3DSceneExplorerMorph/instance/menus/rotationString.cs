rotationString
	^b3DSceneMorph isRotating
		ifTrue: ['stop rotating']
		ifFalse: ['start rotating']