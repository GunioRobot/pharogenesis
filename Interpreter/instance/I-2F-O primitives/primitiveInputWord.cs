primitiveInputWord
	"Return an integer indicating the reason for the most recent input interrupt."

	self pop: 1.
	self pushInteger: 0.	"noop for now"