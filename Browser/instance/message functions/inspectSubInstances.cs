inspectSubInstances
	"Inspect all instances of the selected class and all its subclasses  1/26/96 sw"

	| aClass |
	aClass _ self selectedClassOrMetaClass.
	aClass ~~ nil ifTrue:
		[aClass _ aClass theNonMetaClass.
		 aClass inspectSubInstances].
