pauseIn: aWorld
	"Suspend playing or recording, either as part of a stop command,
	or as part of a project switch, after which it will be resumed."

	state = #play ifTrue:
		[state _ #suspendedPlay.
		playHand delete.
		aWorld removeHand: playHand.
		playHand _ nil].
	state = #record ifTrue:
		[state _ #suspendedRecord.
		recHand stopReportingEventsTo: self.
		recHand _ nil].

	voiceRecorder ifNotNil:
		[voiceRecorder pause.
		startSoundEvent ifNotNil:
			[startSoundEvent sound: voiceRecorder recordedSound.
			voiceRecorder clearRecordedSound.
			startSoundEvent _ nil]].
