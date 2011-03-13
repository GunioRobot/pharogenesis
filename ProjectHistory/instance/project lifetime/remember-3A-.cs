remember: aProject

	| newTuple |

	newTuple _ self forget: aProject.
	mostRecent addFirst: newTuple.
	mostRecent size > 10 ifTrue: [mostRecent _ mostRecent copyFrom: 1 to: 10].
	self changed