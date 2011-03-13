inspectInstances
	"Inspect all instances of the selected class."

	| myClass |
	(myClass _ self selectedClassOrMetaClass) ifNotNil:
		[myClass theNonMetaClass inspectAllInstances]. 
