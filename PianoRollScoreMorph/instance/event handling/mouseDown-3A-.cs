mouseDown: evt

	| noteMorphs chordRect sound |
	(self notesInRect: ((evt cursorPoint extent: 1@0) expandBy: 2@30)) isEmpty
		ifTrue: ["If not near a note, then put up score edit menu"
				^ self invokeScoreMenu: evt].

	"Clicked near (but not on) a note, so play all notes at the cursor time"
	noteMorphs _ self notesInRect: ((evt cursorPoint extent: 1@0) expandBy: 0@self height).
	chordRect _ (self innerBounds withLeft: evt cursorPoint x) withWidth: 1.
	soundsPlayingMorph _ Morph newBounds: chordRect color: Color green.
	self addMorphBack: soundsPlayingMorph.
	
	soundsPlaying _ IdentityDictionary new.
	noteMorphs do:
		[:m | sound _ m soundOfDuration: 999.0.
		soundsPlaying at: m put: sound.
		SoundPlayer resumePlaying: sound quickStart: false].

