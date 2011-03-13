headLightString
	^b3DSceneMorph headLightIsOn
		ifTrue: ['swich headlight off']
		ifFalse: ['swich headlight on']