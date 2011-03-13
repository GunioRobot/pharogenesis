copyToOther
	"Place this change in the other changeSet also"
	| changeSet other info cls |

	controller controlTerminate.
	changeSet _ parent changeSet.
	other _ (parent parent other: parent) changeSet.

	info _ changeSet classChangeAt: (cls _ self selectedClassOrMetaClass) name.
	info do: [:each | other atClass: cls add: each].

	info _ changeSet methodChanges at: cls name ifAbsent: [Dictionary new].
	info associationsDo: [:ass |
		other atSelector: ass key class: cls put: ass value].
	(parent parent other: parent) launch.
	controller controlInitialize