browseInstVarRefs 
	"1/26/96 sw: real work moved to class, so it can be shared"

	| cls |
	(cls _ self selectedClassOrMetaClass) ifNotNil: [cls browseInstVarRefs]