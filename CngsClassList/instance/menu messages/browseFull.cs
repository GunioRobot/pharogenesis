browseFull
	"Create and schedule a System Browser with the selected class as its opening selection.  1/12/96 sw"

	| myClass |

	(myClass _ self selectedClassOrMetaClass) notNil ifTrue: 
		[BrowserView browseFullForClass: myClass method: parent selectedMessageName from: controller]