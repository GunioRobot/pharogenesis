classVariables
	"Browse class variables selected class. 2/1/96 sw"

	| myClass |

	(myClass _ self selectedClassOrMetaClass) notNil ifTrue: 
		[myClass browseClassVariables]