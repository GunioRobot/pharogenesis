methodInterfaceFor: aSelector
	"Answer the methodInterface object for the given selector, or nil if none in the repository"

	^ AllMethodInterfaces at: aSelector ifAbsent: [nil]