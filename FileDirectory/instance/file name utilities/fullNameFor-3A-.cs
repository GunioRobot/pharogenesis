fullNameFor: fileName
	"Return a corrected, fully-qualified name for the given file name. If the given name is already a full path (i.e., it contains a delimiter character), assume it is already a fully-qualified name. Otherwise, prefix it with the path to this directory. In either case, correct the local part of the file name."
	"Details: Note that path relative to a directory, such as '../../foo' are disallowed by this algorithm."

	| correctedLocalName prefix |
	FileDirectory splitName: fileName to:
		[:filePath :localName |
			correctedLocalName _ self checkName: localName fixErrors: true.
			filePath isEmpty
				ifTrue: [prefix _ pathName]  "path to this directory"
				ifFalse: [prefix _ filePath]].  "path supplied with fileName"

	prefix isEmpty
		ifTrue: [^ correctedLocalName]
		ifFalse: [^ prefix, self pathNameDelimiter asString, correctedLocalName].
