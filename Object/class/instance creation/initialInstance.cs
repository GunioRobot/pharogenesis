initialInstance
	"Answer the first instance of the receiver, generate an error if there is one already"
	self instanceCount > 0 ifTrue: [self error: 'instance(s) already exist.'].
	^ self new