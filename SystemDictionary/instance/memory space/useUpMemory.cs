useUpMemory
	"For testing the low space handler..."
	"Smalltalk installLowSpaceWatcher; useUpMemory"

	| lst |
	lst _ nil.
	[true] whileTrue: [
		lst _ Link new nextLink: lst; yourself.
	].