oldFileNamed: aFileName 
 	"Open a file in the default directory (or in the directory contained
	in the input arg); by default, it's available for reading.  2/12/96 sw
	Prior contents will be overwritten, but not truncated on close.  3/18 di"
	| selection |
	(self isAFileNamed: aFileName) ifTrue:
		[^ self new open: aFileName forWrite: true].

	"File does not exist..."
	selection _ (PopUpMenu labels: 'create a new file
choose another name
cancel')
			startUpWithCaption: (FileDirectory localNameFor: aFileName) , '
does not exist.'.
	selection = 1 ifTrue:
		[^ self new open: aFileName forWrite: true].
	selection = 2 ifTrue:
		[^ self oldFileNamed:
			(FillInTheBlank request: 'Enter a new file name'
						initialAnswer: (FileDirectory localNameFor: aFileName))].
	self halt