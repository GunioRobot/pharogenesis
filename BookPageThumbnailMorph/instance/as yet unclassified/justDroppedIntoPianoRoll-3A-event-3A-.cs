justDroppedIntoPianoRoll: pianoRoll event: evt
	
	| ambientEvent startTimeInScore |
	startTimeInScore _ pianoRoll timeForX: self left.

	ambientEvent _ AmbientEvent new 
		morph: self;
		time: startTimeInScore.

	pianoRoll score addAmbientEvent: ambientEvent.

	"self endTime > pianoRoll scorePlayer durationInTicks ifTrue:
		[pianoRoll scorePlayer updateDuration]"
