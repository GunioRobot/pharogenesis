isPartsDonor
	"answer whether the receiver is PartsDonor"
	self hasExtension
		ifFalse: [^ false].
	^ self extension isPartsDonor