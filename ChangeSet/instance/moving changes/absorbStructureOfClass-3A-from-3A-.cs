absorbStructureOfClass: aClass from: otherChangeSet
	"Absorb into the receiver all the structure and superclass info in the other change set.  Used to write conversion methods."

	| sup next |
	otherChangeSet structures ifNil: [^ self].
	(otherChangeSet structures includesKey: aClass name) ifFalse: [^ self].
	structures ifNil:
		[structures _ Dictionary new.
		superclasses _ Dictionary new].
	sup _ aClass name.
	[(structures includesKey: sup) 
		ifTrue: ["use what is here" true]
		ifFalse: [structures at: sup put: (otherChangeSet structures at: sup).
				next _ otherChangeSet superclasses at: sup.
				superclasses at: sup put: next.
				(sup _ next) = 'nil']
	] whileFalse.


