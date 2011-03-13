newFileNamed: aFileName
 	"create a file in the default directory (or in the directory contained in the input arg), set for write access."
	| selection |
	(self isAFileNamed: aFileName) ifFalse:
		[^ self new open: aFileName forWrite: true].

	"File already exists..."
	selection _ (PopUpMenu labels: 'overwrite that file
choose another name
cancel')
			startUpWithCaption: (FileDirectory localNameFor: aFileName) , '
already exists.'.
	selection = 1 ifTrue:
		[FileDirectory default
			deleteFileNamed: aFileName
			ifAbsent: [self error: 'Sorry, deletion failed'].
		^ self new open: aFileName forWrite: true].
	selection = 2 ifTrue: [
		^ self newFileNamed:
			(FillInTheBlank request: 'Enter a new file name'
				initialAnswer: aFileName)].
	"Return a dummy stream that will absorb all file messages and do nothing"
	"^ RWBinaryOrTextStream on: (DummyStream on: nil)"
	self error: 'Please close this to abort file opening'