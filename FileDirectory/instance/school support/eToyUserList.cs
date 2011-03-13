eToyUserList
	| spec index fd list match |
	spec := self eToyBaseFolderSpec. "something like 'U:\Squeak\users\*-Squeak'."
	spec ifNil:[^ServerDirectory eToyUserListForFileDirectory: self].
	"Compute list of users based on base folder spec"
	index := spec indexOf: $*. "we really need one"
	index = 0 ifTrue:[^ServerDirectory eToyUserListForFileDirectory: self].
	fd := FileDirectory on: (FileDirectory dirPathFor: (spec copyFrom: 1 to: index)).
	"reject all non-directories"
	list := fd entries select:[:each| each isDirectory].
	"reject all non-matching entries"
	match := spec copyFrom: fd pathName size + 2 to: spec size.
	list := list collect:[:each| each name].
	list := list select:[:each| match match: each].
	"extract the names (e.g., those positions that match '*')"
	index := match indexOf: $*.
	list := list collect:[:each|
		each copyFrom: index to: each size - (match size - index)].
	^list