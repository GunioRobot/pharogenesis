beUnsticky
	"If the receiver is marked as sticky, make it now be unsticky"
	self hasExtension
		ifTrue: [self extension sticky: false]