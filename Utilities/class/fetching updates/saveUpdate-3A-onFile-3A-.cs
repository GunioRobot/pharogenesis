saveUpdate: doc onFile: fileName
	"See if the user wants the update stored on a local file.  With or without the update number on the front."

| file fName |
(Preferences valueOfFlag: #updateSavesFile) ifTrue: [
	fName _ fileName.
	(Preferences valueOfFlag: #updateRemoveSequenceNum) ifTrue: [
		1 to: 100 do: [:pos | 
			(fName at: pos) isDigit ifFalse: [
				fName _ fName copyFrom: pos to: fName size.
				doc reset; ascii.
				(FileDirectory default fileExists: fName) ifFalse: [
					file _ FileStream newFileNamed: fName.
					file nextPutAll: doc contents.
					file close].
				^ self]]]].