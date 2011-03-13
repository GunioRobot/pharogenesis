saveUpdate: doc onFile: fileName
	"Save the update on a local file.  With or without the update number on the front, depending on the preference #updateRemoveSequenceNum"

	| file fName pos updateDirectory |

	(FileDirectory default directoryNames includes: 'updates') ifFalse:
		[FileDirectory default createDirectory: 'updates'].
	updateDirectory := FileDirectory default directoryNamed: 'updates'.

	fName := fileName.
	(Preferences valueOfFlag: #updateRemoveSequenceNum) ifTrue:
		[pos := fName findFirst: [:c | c isDigit not].
		fName := fName copyFrom: pos to: fName size].
	doc reset; ascii.
	(updateDirectory fileExists: fName) ifFalse:
		[file := updateDirectory newFileNamed: fName.
		file nextPutAll: doc contents.
		file close].
