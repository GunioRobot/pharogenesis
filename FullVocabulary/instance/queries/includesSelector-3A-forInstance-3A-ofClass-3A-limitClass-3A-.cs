includesSelector: aSelector forInstance: anInstance ofClass: aTargetClass limitClass: mostGenericClass
	"Answer whether the vocabulary includes the given selector for the given class, only considering method implementations in mostGenericClass and lower"

	| classToUse aClass |
	classToUse _ self classToUseFromInstance: anInstance ofClass: aTargetClass.
	^ (aClass _ classToUse whichClassIncludesSelector: aSelector)
		ifNil:
			[false]
		ifNotNil:
			[aClass includesBehavior: mostGenericClass]