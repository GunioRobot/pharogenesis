classVarRefs
	"Request a browser of methods that store into a chosen instance variable"

	| aClass |
	(aClass _ self classOfSelection) ifNotNil:
		[self systemNavigation  browseClassVarRefs: aClass].
