openTranscript 
	"Create and schedule a System Transcript.
	 2/5/96 sw: if there is already one open, then instead of refusing the user permission, just activate the damned thing."

	(Transcript transcriptOpen)
		ifTrue: [ScheduledControllers activateTranscript]
		ifFalse: [Transcript aTranscriptIsOpen.
				TextCollectorView open: Transcript label: 'System Transcript']