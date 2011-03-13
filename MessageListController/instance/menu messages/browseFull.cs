browseFull
	"Create and schedule a full Browser and then select the current class and message.  1/12/96 sw"

	| myClass |
	(myClass _ model selectedClassOrMetaClass) notNil ifTrue: 
		[BrowserView browseFullForClass: myClass method: model selectedMessageName from: self]