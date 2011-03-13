initHierarchyForClass: aClassOrMetaClass
	| tab stab index nonMetaClass |
	centralClass := aClassOrMetaClass.
	nonMetaClass := aClassOrMetaClass theNonMetaClass.
	self systemOrganizer: SystemOrganization.
	metaClassIndicated := aClassOrMetaClass isMeta.
	classList := OrderedCollection new.
	tab := ''.
	nonMetaClass allSuperclasses reverseDo: 
		[:aClass | 
		classList add: tab , aClass name.
		tab := tab , '  '].
	index := classList size + 1.
	nonMetaClass allSubclassesWithLevelDo:
		[:aClass :level |
		stab := ''.  1 to: level do: [:i | stab := stab , '  '].
		classList add: tab , stab , aClass name]
	 	startingLevel: 0.
	self classListIndex: index