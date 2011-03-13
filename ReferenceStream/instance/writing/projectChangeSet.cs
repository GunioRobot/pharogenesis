projectChangeSet
	| pr |
	"The changeSet of the project we are writing"
	(pr _ self project) ifNil: [^ nil].
	^ pr projectChangeSet