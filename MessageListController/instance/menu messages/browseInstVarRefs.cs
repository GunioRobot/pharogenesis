browseInstVarRefs
	"Request a browser of methods that access a chosen instance variable.
	1/15/96 sw"

	| aClass |
	self controlTerminate.
	(aClass _ model selectedClassOrMetaClass) notNil ifTrue: 
		[aClass browseInstVarRefs].
	self controlInitialize