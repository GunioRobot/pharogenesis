stepTime
	"Answer the desired time between steps in milliseconds. This default implementation requests that the 'step' method be called once every second."

	^ costumee ifNotNil: [125] ifNil: [1000]