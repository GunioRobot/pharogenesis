switchStored
	"Disables enabled and enables disabled (see corresponding method 
	comments). "
	self treatedMethods
		keysAndValuesDo: [:mRef :status | status == #enabled
				ifTrue: [self disableCallIn: mRef]
				ifFalse: [self enableCallIn: mRef]]