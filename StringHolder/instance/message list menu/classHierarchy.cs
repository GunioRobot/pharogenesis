classHierarchy
	"Create and schedule a class list browser on the receiver's hierarchy."

	Utilities spawnHierarchyForClass: self selectedClassOrMetaClass "OK if nil"
		selector: self selectedMessageName
