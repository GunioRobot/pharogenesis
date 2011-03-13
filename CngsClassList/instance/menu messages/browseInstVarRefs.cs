browseInstVarRefs
	"Browse inst refs for the selected class.  1/15/96 sw"

	| myClass |

	(myClass _ self selectedClassOrMetaClass) notNil ifTrue: 
		[myClass browseInstVarRefs]