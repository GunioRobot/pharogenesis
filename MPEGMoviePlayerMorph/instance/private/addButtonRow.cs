addButtonRow
	"private - add the button row"

	| r |
	r _ AlignmentMorph newRow vResizing: #shrinkWrap; color: Color transparent; listCentering: #center.
	r addMorphBack: (self buttonName: 'Menu' translated action: #invokeMenu).
	r addMorphBack: (Morph new extent: 3@1; color: Color transparent).
	r addMorphBack: (self buttonName: 'Open' translated action: #openMPEGFile).
	r addMorphBack: (Morph new extent: 3@1; color: Color transparent).
	r addMorphBack: (self buttonName: 'Rewind' translated action: #rewindMovie).
	r addMorphBack: (Morph new extent: 3@1; color: Color transparent).
	r addMorphBack: (self buttonName: 'Play' translated action: #startPlaying).
	r addMorphBack: (Morph new extent: 3@1; color: Color transparent).
	r addMorphBack: (self buttonName: 'Stop' translated action: #stopPlaying).
	r addMorphBack: (Morph new extent: 3@1; color: Color transparent).
"
	r addMorphBack: (self buttonName: '<' action: #previousFrame).
	r addMorphBack: (Morph new extent: 3@1; color: Color transparent).
	r addMorphBack: (self buttonName: '>' action: #nextFrame).
	r addMorphBack: (Morph new extent: 3@1; color: Color transparent).
	r addMorphBack: (self buttonName: 'Subtitles' translated action: #openSubtitlesFile).
	r addMorphBack: (Morph new extent: 3@1; color: Color transparent).
"
	r addMorphBack: (self buildQuitButton).

	self addMorphBack: r.
