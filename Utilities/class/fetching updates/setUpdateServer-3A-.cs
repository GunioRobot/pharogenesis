setUpdateServer: groupName
	"Utilities setUpdateServer: 'Squeakland' "
	| entry index |


	entry := UpdateUrlLists detect: [:each | each first = groupName] ifNone: [^self].
	index := UpdateUrlLists indexOf: entry.
	UpdateUrlLists removeAt: index.
	UpdateUrlLists addFirst: entry