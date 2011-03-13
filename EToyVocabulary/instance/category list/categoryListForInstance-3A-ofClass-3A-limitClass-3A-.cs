categoryListForInstance: anObject ofClass: aClass limitClass: mostGenericClass
	"Answer the category list for the given object, considering only code implemented in aClass and lower"

	^ (anObject isKindOf: Player)
		ifTrue:
			[(mostGenericClass == aClass)
				ifFalse:
					[anObject categories]
				ifTrue:
					[#(scripts #'instance variables')]]
		ifFalse:
			[super categoryListForInstance: anObject ofClass: aClass limitClass: mostGenericClass]