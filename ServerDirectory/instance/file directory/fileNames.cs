fileNames
	"Return a collection of names for the files (but not directories) in this directory."
	"(ServerDirectory serverNamed: 'UIUCArchive') fileNames"

	(type == #ftp) | (type == #file) ifFalse: [
		^ self error: 'To see a directory, use file:// or ftp://'].
	^ (self entries select: [:entry | (entry at: 4) not])
		collect: [:entry | entry first]
