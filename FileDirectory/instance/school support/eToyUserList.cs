eToyUserList
	| spec index fd list match |
	spec _ self eToyBaseFolderSpec. "something like 'U:\Squeak\users\*-Squeak'."
	spec ifNil:[^ServerDirectory eToyUserListForFileDirectory: self].
	"Compute list of users based on base folder spec"
	index _ spec indexOf: $*. "we really need one"
	index = 0 ifTrue:[^ServerDirectory eToyUserListForFileDirectory: self].
	fd _ FileDirectory on: (FileDirectory dirPathFor: (spec copyFrom: 1 to: index)).
	"reject all non-directories"
	list _ fd entries select:[:each| each isDirectory].
	"reject all non-matching entries"
	match _ spec copyFrom: fd pathName size + 2 to: spec size.
	list _ list collect:[:each| each name].
	list _ list select:[:each| match match: each].
	"extract the names (e.g., those positions that match '*')"
	index _ match indexOf: $*.
	list _ list collect:[:each|
		each copyFrom: index to: each size - (match size - index)].
	^list