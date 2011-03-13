ifError: aBlock
    | errorBlock lastHandler val activeControllerProcess  |
	activeControllerProcess _ ScheduledControllers activeControllerProcess.
	lastHandler _ activeControllerProcess errorHandler.
    errorBlock _
        [:aString :aReceiver |  activeControllerProcess errorHandler: lastHandler.
        ^ aBlock value: aString].
    activeControllerProcess errorHandler: errorBlock.
    val _ self value.
    activeControllerProcess errorHandler: lastHandler.
    ^ val