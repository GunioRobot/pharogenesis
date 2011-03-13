beIsolated
	"Establish an isolation layer at this project.
	This requires clearing the current changeSet or installing a new one."

	isolatedHead ifTrue: [^ self error: 'Already isolated'].
	self isCurrentProject ifFalse:
		[^ self inform: 'Must be in this project to isolate it'.].
	changeSet isEmpty ifFalse: [changeSet _ ChangeSorter newChangeSet].
	changeSet beIsolationSetFor: self.
	isolatedHead _ true.
	inForce _ true.
	environment _ Environment new setName: self name outerEnvt: Smalltalk.

