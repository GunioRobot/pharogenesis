fullNameFor: fileName
	"Return the fully-qualified path name for the given file. Correct syntax errors in the file name."

	FileDirectory splitName: fileName to: [:path :localName |
		^ (path isEmpty ifFalse: [path] ifTrue: [
			pathName = self pathNameDelimiter asString ifTrue: [''] ifFalse: [pathName]]),
				self pathNameDelimiter asString, (self checkName: localName fixErrors: true)].
