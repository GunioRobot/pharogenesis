setUpdateServer: groupName
	"Utilities setUpdateServer: 'Squeakland' "
	| entry index |


	entry _ UpdateUrlLists detect: [:each | each first = groupName] ifNone: [^self].
	index _ UpdateUrlLists indexOf: entry.
	UpdateUrlLists removeAt: index.
	UpdateUrlLists addFirst: entry