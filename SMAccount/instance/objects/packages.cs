packages
	"Return all owned packages."

	^objects select: [:o | o isPackage]