includesSelector: aSelector forInstance: anInstance ofClass: aTargetClass limitClass: mostGenericClass
	"Answer whether the vocabulary includes the given selector for the given object, only considering method implementations in mostGenericClass and lower"

	^ (super includesSelector: aSelector forInstance: anInstance ofClass: aTargetClass limitClass: mostGenericClass) and:
		[self includesSelector: aSelector]