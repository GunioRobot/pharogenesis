getLastCheckpointWithFilename
	"Return a readstream on a fresh checkpoint gzipped imagesegment.
	First we check if we are dirty and must create a new checkpoint.
	The filename is tacked on at the end so that the checkpoint number
	can be used on the client side too."

	| directory fname |
	isDirty ifTrue: [self createCheckpoint].
	directory _ self directory.
	fname _ self lastCheckpointFilename.
	fname ifNil: [self error: 'No checkpoint available'].
	^((directory oldFileNamed: fname)
		converter: Latin1TextConverter new;
	 	contentsOfEntireFile), ':', fname