oldFileOrNoneNamed: fileName
	"If the file exists, answer a read-only FileStream on it. If it doesn't, answer nil."

	| fullName |
	fullName _ FileStream fullName: fileName.
	(FileStream concreteStream isAFileNamed: fullName)
		ifTrue: [^ FileStream concreteStream readOnlyFileNamed: fullName]
		ifFalse: [^ nil].
