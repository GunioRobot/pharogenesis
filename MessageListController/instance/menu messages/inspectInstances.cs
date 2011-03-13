inspectInstances
	"Inspect all instances of the selected class.  1/26/96 sw"

	| myClass |
	self controlTerminate.
	myClass _ model selectedClassOrMetaClass.
	myClass ~~ nil ifTrue:
		[myClass theNonMetaClass inspectAllInstances].
	self controlInitialize