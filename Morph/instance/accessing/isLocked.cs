isLocked
	"answer whether the receiver is Locked"
	self hasExtension
		ifFalse: [^ false].
	^ self extension locked