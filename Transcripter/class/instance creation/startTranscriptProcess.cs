startTranscriptProcess   "Transcripter startTranscriptProcess"
	| activeProcess |
	Transcript _ self newInFrame: Display boundingBox.
	activeProcess _ [Transcript readEvalPrint.
					Smalltalk processShutDownList: true; quitPrimitive]
						newProcess
					priority: Processor userSchedulingPriority.
	activeProcess resume.
	Processor terminateActive
