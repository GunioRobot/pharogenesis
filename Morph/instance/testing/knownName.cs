knownName
	"answer a name by which the receiver is known, or nil if none"
	^ self hasExtension
		ifTrue: [self extension externalName]