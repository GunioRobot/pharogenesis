setNewsGroup: aLine
	"Set the current newsgroup name from the given line of text, which is of the form:
		Newsgroup comp.lang.smalltalk"

	(aLine size > 11)
		ifTrue: [currentNewsgroup _ aLine copyFrom: 11 to: aLine size]
		ifFalse: [currentNewsgroup _ 'unknown newsgroup'].