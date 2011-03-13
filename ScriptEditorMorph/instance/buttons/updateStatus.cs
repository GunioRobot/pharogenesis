updateStatus
	(self topEditor == self) ifTrue:
		[self updateStatusMorph: (submorphs first submorphNamed: 'trigger')]