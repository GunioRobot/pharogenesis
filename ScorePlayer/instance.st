AbstractSound
	subclass: #ScorePlayer
	instanceVariableNames:
		'score instruments overallVolume leftVols rightVols muted rate tempo secsPerTick done repeat ticksSinceStart ticksClockIncr trackEventIndex tempoMapIndex activeSounds activeMIDINotes midiPort midiPlayerProcess durationInTicks '
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Sound-Scores'