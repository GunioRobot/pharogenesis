acceptDroppingMorph: aMorph event: evt
	"In addition to placing this morph in the pianoRoll, add a corresponding
	event to the score so that it will always appear when played, in addition
	to possibly triggering other actions"
	| ambientEvent |
	ambientEvent _ AmbientEvent new morph: aMorph;
							time: (self timeForX: aMorph left).
	super acceptDroppingMorph: aMorph event: evt.
	score addAmbientEvent: ambientEvent.
