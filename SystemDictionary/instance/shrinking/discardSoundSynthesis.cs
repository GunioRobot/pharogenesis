discardSoundSynthesis
	"Discard the sound synthesis facilities, and the methods and classes that use it. This also discards MIDI."

	Smalltalk discardMIDI.
	Smalltalk discardSpeech.
	SystemOrganization removeCategoriesMatching: 'Sound-Interface'.
	Smalltalk at: #GraphMorph ifPresent: [:graphMorph |
		#(playOnce readDataFromFile)
			do: [:sel | graphMorph removeSelector: sel]].
	Smalltalk at: #TrashCanMorph ifPresent: [:trashMorph |
		trashMorph class removeSelector: #samplesForDelete.
		trashMorph class removeSelector: #samplesForMouseEnter.
		trashMorph class removeSelector: #samplesForMouseLeave].
	SystemOrganization removeCategoriesMatching: 'Sound-Synthesis'.
	SystemOrganization removeCategoriesMatching: 'Sound-Scores'.
