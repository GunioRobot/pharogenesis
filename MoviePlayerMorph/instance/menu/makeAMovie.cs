makeAMovie
	| scoreController score |
	frameSize _ 640@480.  frameDepth _ 16.  self makeMyPage; changed.

	(score _ MIDIScore new initialize) "addAmbientEvent: (AmbientEvent new time: 200*60)".
	scoreController _ ScorePlayerMorph new
			onScorePlayer: (ScorePlayer onScore: score) title: 'sMovie'.
	pianoRoll _ PianoRollScoreMorph new on: scoreController scorePlayer.
	self pianoRoll: pianoRoll.  "back link"
	pianoRoll enableDragNDrop;
		useRoundedCorners;
		movieClipPlayer: self;
		borderWidth: 2;
		extent: self width @ 120;
		align: pianoRoll topLeft with: self bottomLeft - (0@2);
		openInWorld.
	scoreController extent: self width @ scoreController height;
		align: scoreController topLeft with: pianoRoll bottomLeft - (0@2);
		openInWorld.

