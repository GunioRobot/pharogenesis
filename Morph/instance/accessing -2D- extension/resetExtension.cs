resetExtension
	"reset the extension slot if it is not needed"
	(self hasExtension
			and: [self extension isDefault])
		ifTrue: [self privateExtension: nil] 