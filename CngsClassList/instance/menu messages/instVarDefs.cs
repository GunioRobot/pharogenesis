instVarDefs
	"Browse inst def refs for the selected class. "

	| myClass |

	(myClass _ self selectedClassOrMetaClass) notNil ifTrue: 
		[myClass browseInstVarDefs]