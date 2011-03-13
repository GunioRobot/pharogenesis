inspectSubInstances
	"Inspect all instances of the selected class and all its subclasses"

	| aClass |
	(aClass _ self selectedClassOrMetaClass) ifNotNil: [
		aClass theNonMetaClass inspectSubInstances].
