context: aContext 
	"Answer an instance of me for debugging the active process starting with the given context."

	^ self new
		process: Processor activeProcess
		controller:
			(ScheduledControllers inActiveControllerProcess
				ifTrue: [ScheduledControllers activeController]
				ifFalse: [nil])
		context: aContext
