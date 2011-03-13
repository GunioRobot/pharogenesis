updateFrom6718
	"self new updateFrom6718"
	"
	call 'TheWorldMenu removeObsolete' to cleanout obsolete ref.
	-----
	0002542: Morphic testing failure, Morph>>overlapsShadowFormbounds
	-----
	revert Decompiler>>#decompileBlock:
	-----
	ServiceAction>>perform:orSendTo: for romain
	----- Adding andreas packages
	"
	
	self script30.
	self flushCaches.
	TheWorldMenu removeObsolete.
	
	Undeclared removeUnreferencedKeys.
	Smalltalk garbageCollect.
	ScheduledControllers := nil.
	Smalltalk garbageCollect.
	
	SMSqueakMap default purge.
	Smalltalk forgetDoIts.

	DataStream initialize.
	Behavior flushObsoleteSubclasses.
	MethodChangeRecord allInstancesDo: [:each | each noteNewMethod: nil].
	
	SmalltalkImage current fixObsoleteReferences.

	Smalltalk flushClassNameCache.
	3 timesRepeat: [
		Smalltalk garbageCollect.
		Symbol compactSymbolTable.
	].
