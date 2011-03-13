browseMethodFull
	| myClass |
	(myClass := self selectedClassOrMetaClass) ifNotNil:
		[ToolSet browse: myClass realClass selector: self selectedMessageName]