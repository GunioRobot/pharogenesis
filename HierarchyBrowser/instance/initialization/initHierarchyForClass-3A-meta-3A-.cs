initHierarchyForClass: theClass meta: meta
	| tab stab index |
	self systemOrganizer: SystemOrganization.
	metaClassIndicated _ meta.
	classList _ OrderedCollection new.
	tab _ ''.
	theClass allSuperclasses reverseDo: 
		[:aClass | 
		classList add: tab , aClass name.
		tab _ tab , '  '].
	index _ classList size + 1.
	theClass allSubclassesWithLevelDo:
		[:aClass :level |
		stab _ ''.  1 to: level do: [:i | stab _ stab , '  '].
		classList add: tab , stab , aClass name]
	 	startingLevel: 0.
	self classListIndex: index