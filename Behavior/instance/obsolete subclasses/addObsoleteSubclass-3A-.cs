addObsoleteSubclass: aClass
	"Weakly remember that aClass was a subclass of the receiver and is now obsolete"
	| obs |

	obs _ ObsoleteSubclasses at: self ifAbsent:[WeakArray new].
	(obs includes: aClass) ifTrue:[^self].
	obs _ obs copyWithout: nil.
	obs _ obs copyWith: aClass.
	ObsoleteSubclasses at: self put: obs.
