trackNumAndMuteButtonFor: trackIndex

	| muteButton instSelector r |
	muteButton _ SimpleSwitchMorph new
		onColor: (Color r: 1.0 g: 0.6 b: 0.6);
		offColor: color;
		color: color;
		label: 'Mute';
		target: scorePlayer;
		actionSelector: #mutedForTrack:put:;
		arguments: (Array with: trackIndex).
	instSelector _ PopUpChoiceMorph new
		extent: 60@14;
		contentsClipped: 'oboe1';
		target: self;
		actionSelector: #atTrack:from:selectInstrument:;
		getItemsSelector: #instrumentChoicesForTrack:;
		getItemsArgs: (Array with: trackIndex).
	instSelector arguments:
		(Array with: trackIndex with: instSelector).
	instrumentSelector at: trackIndex put: instSelector.

	r _ self makeRow
		hResizing: #rigid;
		vResizing: #spaceFill;
		extent: 70@10.
	r addMorphBack:
		(StringMorph
			contents: trackIndex printString
			font: (TextStyle default fontOfSize: 24)).
	trackIndex < 10
		ifTrue: [r addMorphBack: (Morph new color: color; extent: 19@8)]  "spacer"
		ifFalse: [r addMorphBack: (Morph new color: color; extent: 8@8)].  "spacer"
	r addMorphBack:
		(StringMorph new
			extent: 140@14;
			contentsClipped: (scorePlayer infoForTrack: trackIndex)).
	r addMorphBack: (Morph new color: color; extent: 8@8).  "spacer"
	r addMorphBack: instSelector.
	r addMorphBack: (AlignmentMorph newRow color: color).  "spacer"
	r addMorphBack: muteButton.
	^ r

