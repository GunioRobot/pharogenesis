honeIn: enough 
	"Find if there is a smaller n than enough that give the same  
	measure for n."
	self
		assert: [enough isPowerOfTwo].
	enough < 2
		ifTrue: [^ enough].
	^ self
		honeIn: enough
		step: enough // 2
		measure: (self measureFor: enough)
		withIn: self leeway