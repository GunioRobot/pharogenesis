rename: oldFileName toBe: newFileName
	| selection |
	"Rename the file of the given name to the new name. Fail if there is no file of the old name or if there is an existing file with the new name."
	"Modified for retry after GC ar 3/21/98 18:09"

	(self retryWithGC:[self primRename: (self fullNameFor: oldFileName)
						to: (self fullNameFor: newFileName)]
		until:[:result| result notNil]) ~~ nil ifTrue:[^self].
	(self fileExists: oldFileName) ifFalse:[
		^self error:'Attempt to rename a non-existent file'.
	].
	(self fileExists: newFileName) ifTrue:[
		selection _ (PopUpMenu labels:
'delete old version
cancel')
				startUpWithCaption: 'Trying to rename a file to be
', newFileName , '
and it already exists.'.
		selection = 1 ifTrue:
			[self deleteFileNamed: newFileName.
			^ self rename: oldFileName toBe: newFileName]].
	^self error:'Failed to rename file'.