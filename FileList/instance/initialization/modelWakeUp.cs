modelWakeUp
	"User has entered or expanded the window -- reopen any remote connection."

	(directory isKindOf: ServerDirectory) ifTrue:
		[directory wakeUp]