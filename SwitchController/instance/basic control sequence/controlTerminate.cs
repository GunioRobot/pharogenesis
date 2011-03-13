controlTerminate 
	"Refer to the comment in Controller|controlTerminate."

	view indicatorReverse.
	self viewHasCursor ifTrue: [self sendMessage]