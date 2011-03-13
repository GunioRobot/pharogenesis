initialInstance
	"Answer the first instance of the receiver, generate an error if there is one already"
	"self instanceCount > 0 ifTrue: [self error: 'instance(s) already exist.']."
		"Debugging test that is very slow"
	self deprecated: 'Do not use this method.' on: '14 September 2009' in: #Pharo1.0.
	^ self new