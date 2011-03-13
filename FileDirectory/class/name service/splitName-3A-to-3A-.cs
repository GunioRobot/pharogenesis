splitName: fileName to: volAndNameBlock
	"Take the file name and convert it into a volume name and a fileName.  FileName must be of the form: d:f where the optional d: specifies a known directory and f is the file name within that directory."
	| delimiter colonIndex realName dirName |
	delimiter _ self pathNameDelimiter.
	(colonIndex _ fileName findLast: [:c | c = delimiter]) = 0
		ifTrue:
			[dirName _ String new.
			realName _ fileName ]
		ifFalse:
			[dirName _ fileName copyFrom: 1 to: colonIndex - 1.
			realName _ fileName copyFrom: colonIndex + 1 to: fileName size ].

	^ volAndNameBlock value: dirName value: realName