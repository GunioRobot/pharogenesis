fullPath: serverAndDirectory
	"Parse and save a full path.  Separate out fileName at the end."

	| delim ii |
	super fullPath: serverAndDirectory.		"set server and directory"
	type == #file ifTrue: [fileName _  ''. ^ self].
	delim _ self pathNameDelimiter.
	ii _ directory findLast: [:c | c = delim].
	ii = 0
		ifTrue: [self error: 'expecting directory and fileName']
		ifFalse: [fileName _ directory copyFrom: ii+1 to: directory size.
			directory _ (directory copyFrom: 1 to: directory size - fileName size - 1)].