copyToOther
	"Place this change in the other changeSet also"
	| changeSet other info cls sel |
	listIndex = 0 ifTrue: [^ self].

	controller controlTerminate.
	changeSet _ parent changeSet.
	other _ (parent parent other: parent) changeSet.
	cls _ parent selectedClassOrMetaClass.
	sel _ self selection asSymbol.

	info _ changeSet methodChanges at: cls name ifAbsent: [Dictionary new].
	other atSelector: sel
		class: cls 
		put: (info at: sel).
	(parent parent other: parent) launch.
	controller controlInitialize