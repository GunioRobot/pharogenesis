removeClassFromSystem: aClass
	"Delete the class, aClass, from the system.
	 7/18/96 sw: now that removeClassChanges doesn't remove the changes for the metaclass, call removeClassAndMetaClassChanges: instead"

	SystemChanges removeClassAndMetaClassChanges: aClass.
	SystemOrganization removeElement: aClass name.
	self removeKey: aClass name.
	self flushClassNameCache
