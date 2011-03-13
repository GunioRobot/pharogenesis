splitName: fullName to: pathAndNameBlock
	"Take the file name and convert it to the path name of a directory and a local file name within that directory. FileName must be of the form: <dirPath><delimiter><localName>, where <dirPath><delimiter> is optional. The <dirPath> part may contain delimiters."

	| delimiter i dirName localName |
	delimiter _ self pathNameDelimiter.
	(i _ fullName findLast: [:c | c = delimiter]) = 0
		ifTrue:
			[dirName _ String new.
			localName _ fullName]
		ifFalse:
			[dirName _ fullName copyFrom: 1 to: (i - 1 max: 1).
			localName _ fullName copyFrom: i + 1 to: fullName size].

	^ pathAndNameBlock value: dirName value: localName