fileOrDirectoryExists: filenameOrPath
	"Answer true if either a file or a directory file of the given name exists. The given name may be either a full path name or a local name within this directory."
	"FileDirectory default fileOrDirectoryExists: Smalltalk sourcesName"

	| fName dir |
	DirectoryClass splitName: filenameOrPath to:
		[:filePath :name |
			fName _ name.
			filePath isEmpty
				ifTrue: [dir _ self]
				ifFalse: [dir _ FileDirectory on: filePath]].

	^ (dir includesKey: fName) or: [ fName = '' and:[ dir entries size > 1]]