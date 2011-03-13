recordWithLevel: recordLevel
	"Initialize my sound samples by recording a snippet of sound while the mouse is held down. Trim off leading and trailing silence, and normalize the level of the recording."

	| recorder |
	"record the sound"
	recorder := SoundRecorder new
		samplingRate: samplingRate;
		recordLevel: recordLevel;
		clearRecordedSound.
	Utilities
		informUser: 'Recording a phoneme. Release the mouse button when done.'
		during: [
			recorder resumeRecording.
			Sensor waitNoButton.
			recorder stopRecording].
	Utilities
		informUser: 'Removing leading/trailing silence...'
		during: [
			samples := recorder condensedSamples.
			samples size > 0 ifTrue: [
				samples := self trimAndNormalize: samples]].

	self clearFeatures.
