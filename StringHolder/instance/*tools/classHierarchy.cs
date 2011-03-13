classHierarchy
	"Create and schedule a class list browser on the receiver's hierarchy."

	self systemNavigation
		spawnHierarchyForClass: self selectedClassOrMetaClass "OK if nil"
		selector: self selectedMessageName
