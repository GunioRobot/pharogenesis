removeObsoleteSubclass: aClass
	"Remove aClass from the weakly remembered obsolete subclasses"
	| obs |
	obs _ ObsoleteSubclasses at: self ifAbsent:[^ self].
	(obs includes: aClass) ifFalse:[^self].
	obs _ obs copyWithout: aClass.
	obs _ obs copyWithout: nil.
	ObsoleteSubclasses at: self put: obs