saveUpdate: doc onFile: fileName
	"Save the update on a local file.  With or without the update number on the front, depending on the preference #updateRemoveSequenceNum"

	| file fName pos updateDirectory |

	(FileDirectory default directoryNames includes: 'updates') ifFalse:
		[FileDirectory default createDirectory: 'updates'].
	updateDirectory _ FileDirectory default directoryNamed: 'updates'.

	fName _ fileName.
	(Preferences valueOfFlag: #updateRemoveSequenceNum) ifTrue:
		[pos _ fName findFirst: [:c | c isDigit not].
		fName _ fName copyFrom: pos to: fName size].
	doc reset; ascii.
	(updateDirectory fileExists: fName) ifFalse:
		[file _ updateDirectory newFileNamed: fName.
		file nextPutAll: doc contents.
		file close].
