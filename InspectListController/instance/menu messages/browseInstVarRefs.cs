browseInstVarRefs
	"Request a browser of methods that access a chosen instance variable"

	| aClass |
	self controlTerminate.
	(aClass _  self classOfSelection) notNil ifTrue: 
		[aClass browseInstVarRefs].
	self controlInitialize