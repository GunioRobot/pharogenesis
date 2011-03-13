contentsOfEntireFile
	"Fetch the data off the server and store it in me.  But not if I already have it."

	readLimit _ readLimit max: position.
	readLimit > 0 ifTrue: [^ super contentsOfEntireFile].
	collection size = 0 ifTrue: [self on: (String new: 2000)].
	remoteFile getFileNamed: remoteFile fileName into: self.
	^ super contentsOfEntireFile