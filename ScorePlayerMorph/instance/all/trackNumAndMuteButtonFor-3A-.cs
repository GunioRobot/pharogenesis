trackNumAndMuteButtonFor: trackIndex

	| muteButton instrumentChooser r |
	muteButton _ SimpleSwitchMorph new
		onColor: (Color r: 1.0 g: 0.6 b: 0.6);
		offColor: color;
		color: color;
		label: 'Mute';
		target: scorePlayer;
		actionSelector: #mutedForTrack:put:;
		arguments: (Array with: trackIndex).
	instrumentChooser _ PopUpChoiceMorph new
		extent: 60@14;
		contentsClipped: 'oboe1';
		target: self;
		actionSelector: #atTrack:from:selectInstrument:;
		getItemsSelector: #instrumentChoicesForTrack:;
		getItemsArgs: (Array with: trackIndex).
	instrumentChooser arguments:
		(Array with: trackIndex with: instrumentChooser).
	
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
	r addMorphBack: instrumentChooser.
	r addMorphBack: (LayoutMorph newRow color: color).  "spacer"
	r addMorphBack: muteButton.
	^ r

