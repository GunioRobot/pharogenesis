finalCleanup
	"ReleaseBuilder new finalCleanup"


	Smalltalk forgetDoIts.

	DataStream initialize.
	Behavior flushObsoleteSubclasses.

	"The pointer to currentMethod is not realy needed (anybody care to fix this) and often holds on to obsolete bindings"
	MethodChangeRecord allInstancesDo: [:each | each noteNewMethod: nil].

	self cleanUpEtoys.
	SmalltalkImage current fixObsoleteReferences.

	Smalltalk flushClassNameCache.
	3 timesRepeat: [
		Smalltalk garbageCollect.
		Symbol compactSymbolTable.
	].
