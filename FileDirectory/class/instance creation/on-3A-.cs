on: pathString
	"Return a new file directory for the given path, of the appropriate FileDirectory subclass for the current OS platform."

	| pathName |
	DirectoryClass ifNil: [DirectoryClass _ self activeDirectoryClass].
	"If path ends with a delimiter (: or /) then remove it"
	((pathName _ pathString) endsWith: self pathNameDelimiter asString) ifTrue: [
		pathName _ pathName copyFrom: 1 to: pathName size - 1].
	^ DirectoryClass new setPathName: pathName
