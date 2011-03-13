step

	| now |

	self server ifNil: [ ^self ].
	self server step.
	now _ Time millisecondClockValue.
	(now - lastFullUpdateTime) abs > 5000 ifTrue: [
		lastFullUpdateTime _ now.
		(previousBacklog = self server backlog and: [self server clients = previousClients]) ifFalse: [
			previousClients _ self server clients copy.
			self rebuild
		]
	].
