layoutProperties
	"Return the current layout properties associated with the  
	receiver"
	^ self hasExtension
		ifTrue: [self extension layoutProperties]