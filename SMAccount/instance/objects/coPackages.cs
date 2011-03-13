coPackages
	"Return all co-maintained packages."

	^coObjects select: [:o | o isPackage]