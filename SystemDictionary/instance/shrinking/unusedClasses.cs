unusedClasses
	"Enumerates all classes in the system and returns a list of those that are 
	apparently unused. A class is considered in use if it (a) has subclasses 
	or (b) is referred to by some method or (c) has its name in use as a 
	literal. "
	"Smalltalk unusedClasses asSortedCollection"
	^ self systemNavigation allUnusedClassesWithout: {{}. {}}