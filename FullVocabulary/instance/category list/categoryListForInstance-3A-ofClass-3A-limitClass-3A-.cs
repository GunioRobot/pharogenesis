categoryListForInstance: anObject ofClass: aClass limitClass: mostGenericClass
	"Answer the category list for the given object, considering only code implemented in mostGeneric and lower (or higher, depending on which way you're facing"

	| classToUse |
	classToUse := anObject ifNil: [aClass] ifNotNil: [anObject class].
	^ mostGenericClass == classToUse
		ifTrue:
			[mostGenericClass organization categories]
		ifFalse:
			[classToUse allMethodCategoriesIntegratedThrough: mostGenericClass]