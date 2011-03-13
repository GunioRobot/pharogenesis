browseMethodFull
	"Create and schedule a full Browser and then select the current class and message."

	| myClass |
	(myClass := self selectedClassOrMetaClass) ifNotNil:
		[Browser fullOnClass: myClass selector: self selectedMessageName]