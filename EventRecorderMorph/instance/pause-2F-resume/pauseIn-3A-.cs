pauseIn: aWorld
	"Suspend playing or recording, either as part of a stop command,
	or as part of a project switch, after which it will be resumed."

	self setStatusLight: #ready.
	state = #play ifTrue:
		[state _ #suspendedPlay.
		playHand delete.
		aWorld removeHand: playHand.
		playHand _ nil].
	state = #record ifTrue:
		[state _ #suspendedRecord.
		recHand removeEventListener: self.
		recHand _ nil].

	voiceRecorder ifNotNil:
		[voiceRecorder pause.
		startSoundEvent ifNotNil:
			[startSoundEvent argument: voiceRecorder recordedSound.
			voiceRecorder clearRecordedSound.
			startSoundEvent _ nil]].
