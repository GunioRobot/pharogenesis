updateFileList
	"Update my files list with file names in the current directory that match the pattern."
	"wod 5/27/1998: nil out the fileName."
	Cursor execute showWhile:
		[list _ (pattern includes: $*) | (pattern includes: $#)
			ifTrue: [self listForPattern: pattern]
			ifFalse: [
				pattern isEmpty
					ifTrue: [self listForPattern: '*']
					ifFalse: [self listForPattern: '*', pattern, '*']].
		listIndex _ 0.
		volListIndex _ volList size.
		fileName _ nil.
		contents _ ''.
		self changed: #volumeListIndex.
		self changed: #fileList].
