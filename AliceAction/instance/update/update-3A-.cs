update: currentTime
	"Execute the Action's task"

	paused ifFalse: [ actionTask value ].

