directoryNames
	"Return a collection of names for the subdirectories of this directory."
	"(ServerDirectory serverNamed: 'UIUCArchive') directoryNames"

	^ (self entries select: [:entry | entry at: 4])
		collect: [:entry | entry first]
