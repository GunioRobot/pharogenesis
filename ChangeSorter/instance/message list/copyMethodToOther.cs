copyMethodToOther
	"Place this change in the other changeSet also"
	| other info cls sel |

	currentSelector ifNotNil: [
		other _ (parent other: self) changeSet.
		cls _ self selectedClassOrMetaClass.
		sel _ currentSelector asSymbol.

		info _ myChangeSet methodChanges at: cls name ifAbsent: [Dictionary new].
		other atSelector: sel
			class: cls 
			put: (info at: sel).
		(parent other: self) showChangeSet: other]
