makeSqueaklandReleasePhaseCleanup
	"ReleaseBuilder new makeSqueaklandReleasePhaseCleanup"

	Browser initialize.
	ChangeSorter 
		removeChangeSetsNamedSuchThat: [:cs | cs name ~= ChangeSet current name].
	ChangeSet current clear.
	ChangeSet current name: 'Unnamed1'.
	Smalltalk garbageCollect.
	"Reinitialize DataStream; it may hold on to some zapped entitities"
	DataStream initialize.
	"Remove existing player references"
	References keys do: [:k | References removeKey: k].
	Smalltalk garbageCollect.
	ScheduledControllers := nil.
	Behavior flushObsoleteSubclasses.
	Smalltalk
		garbageCollect;
		garbageCollect.
	SystemNavigation default obsoleteBehaviors isEmpty 
		ifFalse: [self error: 'Still have obsolete behaviors'].

	"Reinitialize DataStream; it may hold on to some zapped entitities"
	DataStream initialize.
	Smalltalk fixObsoleteReferences.
	Smalltalk abandonTempNames.
	Smalltalk zapAllOtherProjects.
	Smalltalk forgetDoIts.
	Smalltalk flushClassNameCache.
	3 timesRepeat: 
			[Smalltalk garbageCollect.
			Symbol compactSymbolTable]