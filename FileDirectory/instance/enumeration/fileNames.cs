fileNames
	"Return a collection of names for the files (but not directories) in this directory."
	"FileDirectory default fileNames"

	^ (self entries select: [:entry | (entry at: 4) not])
		collect: [:entry | entry first]
