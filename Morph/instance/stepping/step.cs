step
	"Do some periodic activity. Use startStepping/stopStepping to start and stop getting sent this message. The time between steps is specified by this morph's answer to the stepTime message. This default implementation does nothing."
	costumee ifNotNil: [costumee step]
