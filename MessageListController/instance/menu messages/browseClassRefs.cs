browseClassRefs
	"Inspect all instances of the selected class and all its subclasses  1/26/96 sw"

	| aClass |
	self controlTerminate.
	aClass _ model selectedClassOrMetaClass.
	aClass ~~ nil ifTrue:
		[aClass _ aClass theNonMetaClass.
		 Smalltalk browseAllCallsOn: (Smalltalk associationAt: aClass name)].
	self controlInitialize