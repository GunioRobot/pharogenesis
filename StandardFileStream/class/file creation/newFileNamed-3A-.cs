newFileNamed: aFileName
 	"create a file in the default directory (or in the directory contained in the input arg), set for write access.  2/12/96 sw.  Fixed 6/13/96 sw so that if deletion of old conflicting file fails, the error raised is more helpful."

	| result |
	(self isAFileNamed: aFileName)
		ifTrue:
			[(self confirm: (self localNameFor: aFileName) , ' already exists.
Do you want to overwrite it?')
				ifTrue: [result _ FileDirectory default deleteFileNamed: aFileName.
					result == nil ifTrue: "deletion failed"
						[self halt: 'Sorry - deletion failed']]
				ifFalse: [self halt]].
	^ self new open: aFileName forWrite: true