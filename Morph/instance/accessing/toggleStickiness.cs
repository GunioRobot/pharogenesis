toggleStickiness
	"togle the receiver's Stickiness"
	self hasExtension
		ifFalse: [^ self beSticky].
	self extension sticky: self extension sticky not