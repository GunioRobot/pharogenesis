updateFileList
	"Update my files list with file names in the current directory that match the pattern."

	Cursor execute showWhile:
		[list _ (pattern includes: $*) | (pattern includes: $#)
			ifTrue: [directory listForPattern: pattern sortMode: sortMode]
			ifFalse: [
				pattern isEmpty
					ifTrue: [directory listForPattern: '*' sortMode: sortMode]
					ifFalse: [directory listForPattern: '*', pattern, '*' sortMode: sortMode]].
		listIndex _ 0.
		volListIndex _ volList size.
		contents _ ''.
		self changed: #volumeListIndex.
		self changed: #fileList].
