contents: anSMObject
	"Return contents of the file for the object
	or nil if not in cache."

	anSMObject isCached
		ifTrue: [^(anSMObject cacheDirectory readOnlyFileNamed: anSMObject downloadFileName) binary; contentsOfEntireFile]
		ifFalse: [^nil]
		