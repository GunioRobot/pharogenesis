fileExists: filenameOrPath
	"Answer true if a file of the given name exists. The given name may be either a full path name or a local file within this directory."

	| fullName |
	FileDirectory splitName: filenameOrPath to:
		[:filePath :ignore |
			filePath isEmpty
				ifTrue: [  "file in this directory"
					fullName _ pathName, self pathNameDelimiter asString, filenameOrPath]
				ifFalse: [  "file has its own path"
					fullName _ filenameOrPath]].

	^ StandardFileStream isAFileNamed: fullName
