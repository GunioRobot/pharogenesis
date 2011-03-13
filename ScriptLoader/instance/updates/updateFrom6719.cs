updateFrom6719
	"self new updateFrom6719"
	"
	0002135: Cmd-. don't work with various Mac Os X keyboard layout
	"
	
	self script31.
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
