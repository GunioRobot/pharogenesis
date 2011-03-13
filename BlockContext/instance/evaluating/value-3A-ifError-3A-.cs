value: arg1 ifError: aBlock
    | errorBlock lastHandler val activeControllerProcess  |
	activeControllerProcess _ ScheduledControllers activeControllerProcess.
	lastHandler _ activeControllerProcess errorHandler.
    errorBlock _
        [:aString :aReceiver |  activeControllerProcess errorHandler: lastHandler.
        ^ aBlock value: aString value: aReceiver].
    activeControllerProcess errorHandler: errorBlock.
    val _ self value: arg1.
    activeControllerProcess errorHandler: lastHandler.
    ^ val