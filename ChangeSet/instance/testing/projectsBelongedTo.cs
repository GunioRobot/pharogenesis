projectsBelongedTo
	"Answer a list of all the projects for which the receiver is the current change set"

	^ Project allSubInstances select: [:proj |
		proj projectChangeSet == self]
