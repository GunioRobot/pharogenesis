bindTo: portNumber backlog: aNumber
	"Start listening. Accept only up to aNumber outstanding connections."

	highwater := Semaphore new.
	aNumber timesRepeat: [highwater signal].
	queue := SharedQueue new: aNumber.
	listener := Process forContext: [[
		(socket := Socket new) listenOn: portNumber.
		[socket waitForConnectionUntil: Socket standardDeadline] whileFalse: [
			queue nextPut: nil.
			highwater wait].
		queue nextPut: socket.
		highwater wait.
		true] whileTrue] priority: Processor lowIOPriority.
	listener resume
