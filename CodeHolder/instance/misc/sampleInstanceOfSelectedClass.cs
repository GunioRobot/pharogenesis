sampleInstanceOfSelectedClass
	| aClass |
	"Return a sample instance of the class currently being pointed at"
	(aClass _ self selectedClassOrMetaClass) ifNil: [^ nil].
	^ aClass theNonMetaClass initializedInstance