discardSoundSynthesis
	"Discard the sound synthesis facilities, and the methods and classes that use it. This also discards MIDI."

	Smalltalk discardMIDI.
	Smalltalk removeClassNamed: #EnvelopeLineMorph.
	Smalltalk removeClassNamed: #EnvelopeEditorMorph.
	Smalltalk removeClassNamed: #SoundSequencerMorph.
	Smalltalk removeClassNamed: #SoundMorph.
	Smalltalk removeClassNamed: #SoundLoopMorph.
	Smalltalk removeClassNamed: #InterimSoundMorph.
	Smalltalk removeClassNamed: #RecordingControlsMorph.
	Smalltalk removeClassNamed: #SoundDemoMorph.
	Smalltalk at: #GraphMorph ifPresent: [:graphMorph |
		#(loadCoffeeCupClink play playBach playOnce
		  readDataFromFile registerWaveform stopPlaying)
			do: [:sel | graphMorph removeSelector: sel]].
	Smalltalk at: #TrashCanMorph ifPresent: [:trashMorph |
		trashMorph class removeSelector: #samplesForDelete.
		trashMorph class removeSelector: #samplesForMouseEnter.
		trashMorph class removeSelector: #samplesForMouseLeave].
	SystemOrganization removeCategoriesMatching: 'System-Sound'.
