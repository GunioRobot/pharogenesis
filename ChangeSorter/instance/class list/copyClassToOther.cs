copyClassToOther
	"Place these changes in the other changeSet also"
	| other info cls |

	other _ (parent other: self) changeSet.
	(myChangeSet classRemoves includes: currentClassName) ifTrue: [
			^ other noteRemovalOf: currentClassName].

	info _ myChangeSet classChangeAt: (cls _ self selectedClassOrMetaClass) name.
	info do: [:each | other atClass: cls add: each].

	info _ myChangeSet methodChanges at: cls name ifAbsent: [Dictionary new].
	info associationsDo: [:ass |
		other atSelector: ass key class: cls put: ass value].
	(parent other: self) showChangeSet: other.