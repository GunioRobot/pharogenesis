inspectInstances
	"Inspect all instances of the selected class.  1/26/96 sw"

	| myClass |
	myClass _ self selectedClassOrMetaClass.
	myClass ~~ nil ifTrue:
		[myClass theNonMetaClass inspectAllInstances].
