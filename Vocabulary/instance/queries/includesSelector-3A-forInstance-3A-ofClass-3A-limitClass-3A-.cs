includesSelector: aSelector forInstance: anInstance ofClass: aTargetClass limitClass: mostGenericClass
	"Answer whether the vocabulary includes the given selector for the given class (and instance, if provided), only considering method implementations in mostGenericClass and lower"

	| classToUse aClass |

	(methodInterfaces includesKey: aSelector) ifFalse: [^ false].
	classToUse _ self classToUseFromInstance: anInstance ofClass: aTargetClass.
	^ (aClass _ classToUse whichClassIncludesSelector: aSelector)
		ifNil:
			[false]
		ifNotNil:
			[(aClass includesBehavior: mostGenericClass) and:
				[(self someCategoryThatIncludes: aSelector) notNil]]
