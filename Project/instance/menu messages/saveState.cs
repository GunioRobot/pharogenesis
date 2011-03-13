saveState
	"Save the current state in me prior to switching projects"

	projectWindows _ ScheduledControllers.
	projectChangeSet _ Smalltalk changes.
	projectTranscript _ Transcript.
	displayDepth _ Display depth.
