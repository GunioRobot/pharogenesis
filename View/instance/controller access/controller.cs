controller
	"If the receiver's controller is nil (the default case), answer an initialized 
	instance of the receiver's default controller. If the receiver does not 
	allow a controller, answer the symbol #NoControllerAllowed."

	controller == nil ifTrue: [self controller: self defaultController].
	^controller