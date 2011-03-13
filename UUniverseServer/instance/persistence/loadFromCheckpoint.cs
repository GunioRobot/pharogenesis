loadFromCheckpoint
	"reload from a checkpoint"
	| file savedObject |
	(saveDirectory isAFileNamed: 'checkpoint')
		ifTrue: [ file _ saveDirectory readOnlyFileNamed: 'checkpoint' ]
		ifFalse: [ file _ saveDirectory readOnlyFileNamed: 'checkpoint.die' ].

	savedObject := file fileInObjectAndCode.
	file close.
	
	universe := savedObject first.
	policy := savedObject second.	