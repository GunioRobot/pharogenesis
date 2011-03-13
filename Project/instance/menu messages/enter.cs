enter
	"The user has chosen to change the context of the workspace to be that of 
	the receiver. Change the ChangeSet, Transcript, and collection of 
	scheduled views accordingly."

	CurrentProject saveState.
	CurrentProject _ self.
	Smalltalk newChanges: projectChangeSet.
	TextCollector newTranscript: projectTranscript.
	displayDepth == nil ifTrue: [displayDepth _ Display depth].
	Display newDepthNoRestore: displayDepth.
	ControlManager newScheduler: projectWindows