fileIn
	"File in to a change set named like my file"
	| stream newCS |
	stream := directory readOnlyFileNamed: fileName.
	self class withCurrentChangeSetNamed: fileName
		do: [:cs | newCS := cs. self fileInFrom: stream].
	newCS isEmpty ifTrue: [ ChangeSet removeChangeSet: newCS ]