removeClassFromSystemUnlogged: aClass
	"Delete the class, aClass, from the system, but log the removal neither to the current change set nor to the changes log"

	SystemOrganization removeElement: aClass name.
	self removeFromStartUpList: aClass.
	self removeFromShutDownList: aClass.
	self removeKey: aClass name ifAbsent: [].
	self flushClassNameCache
