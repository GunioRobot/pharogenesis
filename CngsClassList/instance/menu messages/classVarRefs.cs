classVarRefs
	"Browse class var refs for the selected class"

	| myClass |

	(myClass _ self selectedClassOrMetaClass) notNil ifTrue: 
		[myClass browseClassVarRefs]