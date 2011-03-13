installSAR: aFileName from: stream 

 | newCS |

	self classSARInstaller withCurrentChangeSetNamed: aFileName
		do: [:cs | newCS := cs. self classSARInstaller new fileInFrom: stream].
	newCS isEmpty ifTrue: [ self classChangeSet removeChangeSet: newCS ]