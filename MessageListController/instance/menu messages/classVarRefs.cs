classVarRefs
	"Request a browser of methods that access a chosen class variable.
	1/17/96 sw"

	| aClass |
	self controlTerminate.
	(aClass _ model selectedClass) notNil ifTrue: 
		[aClass browseClassVarRefs].
	self controlInitialize