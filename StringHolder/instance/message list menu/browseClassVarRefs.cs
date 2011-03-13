browseClassVarRefs
	"1/17/96 sw: devolve responsibility to the class, so that the code that does the real work can be shared"

	| cls |
	(cls _ self selectedClass) ifNotNil: [cls browseClassVarRefs]