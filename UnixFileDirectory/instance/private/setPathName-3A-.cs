setPathName: pathString
	"Unix path names start with a leading delimiter character."

	(pathString isEmpty or: [pathString first ~= self pathNameDelimiter])
		ifTrue: [pathName _ FilePath pathName: (self pathNameDelimiter asString, pathString)]
		ifFalse: [pathName _ FilePath pathName: pathString].
