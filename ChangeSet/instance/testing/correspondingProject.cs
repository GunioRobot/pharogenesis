correspondingProject
	"If the receiver is the current change set for any project, answer it, else answer nil"

	Project allSubInstancesDo: [:proj |
		proj projectChangeSet == self ifTrue: [^ proj]].
	^ nil
