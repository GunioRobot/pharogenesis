nodeHierarchyWithClass: aClass
	^ OBClassAwareNode sortHierarchically: 
		(self surroundingHierarchy collect: [:ea | aClass on: ea])