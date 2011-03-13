useUpMemory
	"For testing the low space handler..."
	"Smalltalk installLowSpaceWatcher; useUpMemory"

	| lst |
	lst := nil.
	[true] whileTrue: [
		lst := Link nextLink: lst.
	].