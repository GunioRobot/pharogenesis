nextReadyProcess
	quiescentProcessLists reverseDo: [ :list |
		list isEmpty ifFalse: [ | proc |
			proc _ list first.
			proc suspendedContext ifNotNil: [ ^proc ]]].
	^nil