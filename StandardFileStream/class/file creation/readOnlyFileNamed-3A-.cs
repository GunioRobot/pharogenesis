readOnlyFileNamed: aFileName
	"Open a file of the given name for read-only access.  1/31/96 sw"
	| selection |
	(self isAFileNamed: aFileName) ifTrue:
		[^ self new open: aFileName forWrite: false].

	"File does not exist..."
	selection _ (PopUpMenu labels: 'choose another name
cancel')
			startUpWithCaption: (FileDirectory localNameFor: aFileName) , '
does not exist.'.
	selection = 1 ifTrue:
		[^ self readOnlyFileNamed:
			(FillInTheBlank request: 'Enter a new file name'
						initialAnswer: (FileDirectory localNameFor: aFileName))].
	self halt