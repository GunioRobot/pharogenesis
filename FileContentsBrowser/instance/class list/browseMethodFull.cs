browseMethodFull
	| myClass |
	(myClass _ self selectedClassOrMetaClass) ifNotNil:
		[Browser fullOnClass: myClass realClass selector: self selectedMessageName]