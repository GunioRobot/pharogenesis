initialize: anAliceWorld
	"Initialize script by assigning the scheduler and putting default values in the instance variables"

	"Set the script name"
	scriptName _ 'Unnamed'.

	"Set the scheduler for this script"
	myWorld _ anAliceWorld.
	myScheduler _ myWorld getScheduler.

	"By default a script contains no commands"
	myCommands _ OrderedCollection new.

	"By default there are no active commands"
	pendingCommands _ OrderedCollection new.

	"By default there are no active animations"
	activeAnimations _ OrderedCollection new.

	"By default scripts run in order (one command after another)"
	scriptType _ inOrder.

	"By default the script isn't running"
	isRunning _ false.

