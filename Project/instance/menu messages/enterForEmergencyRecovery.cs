enterForEmergencyRecovery
	"This version of enter invokes an absolute minimum of mechanism.
	An unrecoverable error has been detected in an isolated project.
	It is assumed that the old changeSet has already been revoked.
	No new process gets spawned here.  This will happen in the debugger."

	self isCurrentProject ifTrue: [^ self].
	CurrentProject saveState.
	CurrentProject _ self.
	Display newDepthNoRestore: displayDepth.
	ChangeSet  newChanges: changeSet.
	TranscriptStream newTranscript: transcript.
	World pauseEventRecorder.

	world isMorph
		ifTrue:
			["Entering a Morphic project"
			World _ world.
			world install.
			world triggerOpeningScripts]
		ifFalse:
			["Entering an MVC project"
			World _ nil.
			Smalltalk at: #ScheduledControllers put: world.
			ScheduledControllers restore].
	UIProcess _ Processor activeProcess.
