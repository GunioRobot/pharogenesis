withAllSubdirectoriesCollect: aBlock
	"Evaluate aBlock with each of the directories in the subtree of the file system whose root is this directory.
	Answer the results of these evaluations."

	| result todo dir |
	result _ OrderedCollection new: 100.
	todo _ OrderedCollection with: self.
	[todo size > 0] whileTrue: [
		dir _ todo removeFirst.
		result add: (aBlock value: dir).
		dir directoryNames do: [:n | todo add: (dir directoryNamed: n)]].
	^ result
