browseInstVarRefs 
	"1/26/96 sw: real work moved to class, so it can be shared"

	classListIndex = 0 ifTrue: [^ self].
	self selectedClassOrMetaClass browseInstVarRefs