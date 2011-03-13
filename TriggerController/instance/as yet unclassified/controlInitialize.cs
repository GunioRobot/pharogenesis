controlInitialize 
	"Do the action upon mouse DOWN.  Don't bother to reverse the view since this the action happens immediately."

	self viewHasCursor ifTrue: [self sendMessage]