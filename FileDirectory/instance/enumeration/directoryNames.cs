directoryNames
	"Return a collection of names for the subdirectories of this directory."
	"FileDirectory default directoryNames"

	^ (self entries select: [:entry | entry at: 4])
		collect: [:entry | entry first]
