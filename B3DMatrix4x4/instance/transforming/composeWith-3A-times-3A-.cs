composeWith: m2 times: nTimes

	"Perform a 4x4 matrix exponentiation and multiplication."

	| result |
	result _ self.
	nTimes negative ifTrue: [ self halt ].
	nTimes >= 2 ifTrue: [ 
			result _ result composeWith: (m2 composedWithLocal: m2) times: nTimes // 2 ].
	(nTimes \\ 2) = 1 ifTrue: [ result _ result composedWithLocal: m2].
	^ result
	
