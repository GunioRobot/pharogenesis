initHierarchyForClass: aClassOrMetaClass
	| tab stab index nonMetaClass |
	centralClass _ aClassOrMetaClass.
	nonMetaClass _ aClassOrMetaClass theNonMetaClass.
	self systemOrganizer: SystemOrganization.
	metaClassIndicated _ aClassOrMetaClass isMeta.
	classList _ OrderedCollection new.
	tab _ ''.
	nonMetaClass allSuperclasses reverseDo: 
		[:aClass | 
		classList add: tab , aClass name.
		tab _ tab , '  '].
	index _ classList size + 1.
	nonMetaClass allSubclassesWithLevelDo:
		[:aClass :level |
		stab _ ''.  1 to: level do: [:i | stab _ stab , '  '].
		classList add: tab , stab , aClass name]
	 	startingLevel: 0.
	self classListIndex: index