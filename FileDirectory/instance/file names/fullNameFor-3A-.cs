fullNameFor: fileName
	(pathName isEmpty
		or: [fileName includes: self pathNameDelimiter])
		ifTrue: [^ fileName].
	^ pathName , self pathNameDelimiter asString , fileName