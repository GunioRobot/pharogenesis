enter
	"The user has chosen to change the context of the workspace to be that of 
	the receiver. Change the ChangeSet, Transcript, and collection of 
	scheduled views accordingly."

	CurrentProject saveState.
	CurrentProject _ self.
	Smalltalk newChanges: changeSet.
	TextCollector newTranscript: transcript.
	displayDepth == nil ifTrue: [displayDepth _ Display depth].
	Display newDepthNoRestore: displayDepth.
	world isMorph ifFalse: [World _ nil.  ^ ControlManager newScheduler: world].
	(World _ world) install.
	self spawnNewProcess