privateCleanup
	queuesMutex critical: [
		defaultQueue isEmpty ifTrue: [defaultQueue _ nil].
		queueDict ifNotNil: [
			queueDict copy keysAndValuesDo: [:id :queue | 
				queue isEmpty ifTrue: [queueDict removeKey: id]].
			queueDict isEmpty ifTrue: [queueDict _ nil].
		].
	].