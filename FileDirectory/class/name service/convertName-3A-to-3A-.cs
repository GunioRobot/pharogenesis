convertName: fileName to: volAndNameBlock
	"Convert the fileName to a directory object and a local fileName.  FileName must be of the form: <path><name> where the optional <path> specifies a known directory and <name> is the file name within that directory."
	| i delim |
	(fileName includes: (delim_ self pathNameDelimiter))
		ifFalse: [^ volAndNameBlock
					value: DefaultDirectory
						value: fileName].
	i _ fileName findLast: [:c | c = delim].
	^ volAndNameBlock
		value: (self newOnPath: (fileName copyFrom: 1 to: i - 1))
		value: (fileName copyFrom: i + 1 to: fileName size)