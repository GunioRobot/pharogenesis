classVarRefs
	"Request a browser of methods that store into a chosen instance variable"

	| aClass |
	self controlTerminate.
	(aClass _  self classOfSelection) notNil ifTrue: 
		[aClass browseClassVarRefs].
	self controlInitialize