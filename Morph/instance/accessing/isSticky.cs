isSticky
	"answer whether the receiver is Sticky"
	self hasExtension
		ifFalse: [^ false].
	^ self extension sticky