visible
	"answer whether the receiver is visible"
	self hasExtension
		ifFalse: [^ true].
	^ self extension visible