copyMethodToOther
	"Place this change in the other changeSet also"
	| other cls sel |
	self checkThatSidesDiffer: [^ self].
	currentSelector ifNotNil:
		[other _ (parent other: self) changeSet.
		cls _ self selectedClassOrMetaClass.
		sel _ currentSelector asSymbol.

		other absorbMethod: sel class: cls from: myChangeSet.
		(parent other: self) showChangeSet: other]
