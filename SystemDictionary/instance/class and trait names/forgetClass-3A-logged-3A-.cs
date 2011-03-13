forgetClass: aClass logged: aBool 
	"Delete the class, aClass, from the system.
	Note that this doesn't do everything required to dispose of a class - to do that use Class>>removeFromSystem."

	aBool ifTrue: [SystemChangeNotifier uniqueInstance classRemoved: aClass fromCategory: aClass category].		
	SystemOrganization removeElement: aClass name.
	self removeFromStartUpList: aClass.
	self removeFromShutDownList: aClass.
	self removeKey: aClass name ifAbsent: [].
	self flushClassNameCache