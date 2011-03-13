installProject
	"Assume that we're loading a single file and it's a project"
	| aStream |
	aStream _ sourceFiles first contentStream.
	aStream ifNil:[^self error:'Project was not loaded'].
	ProjectLoading
			openFromFile: aStream
			fromDirectory: nil
			withProjectView: nil.
