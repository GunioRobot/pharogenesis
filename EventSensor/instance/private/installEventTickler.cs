installEventTickler
	"Initialize the interrupt watcher process. Terminate the old process if any."
	"Sensor installEventTickler"

	EventTicklerProcess ifNotNil: [EventTicklerProcess terminate].
	EventTicklerProcess _ [self eventTickler] forkAt: Processor lowIOPriority.
