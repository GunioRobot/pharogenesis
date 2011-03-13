categoryListForInstance: anObject ofClass: aClass limitClass: mostGenericClass
	"Answer the category list for the given object/class, considering only code implemented in mostGenericClass and lower"

	^ (super categoryListForInstance: anObject ofClass: aClass limitClass: mostGenericClass) select:
		[:aCategory | categoryScreeningBlock value: aCategory]