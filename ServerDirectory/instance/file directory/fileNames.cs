fileNames
	"Return a collection of names for the files (but not directories) in this directory."
	"(ServerDirectory serverNamed: 'UIUCArchive') fileNames"

	^ self entries select: [:entry | (entry at: 4) not]
		thenCollect: [:entry | entry first]
