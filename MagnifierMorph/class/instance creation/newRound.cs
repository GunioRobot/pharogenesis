newRound
	"Answer a round Magnifier"

	| aMagnifier sm |
	aMagnifier _ self new.
	sm _ ScreeningMorph new position: aMagnifier position.
	sm addMorph: aMagnifier.
	sm addMorph: (EllipseMorph newBounds: aMagnifier bounds).
	sm setNameTo: 'Magnifier'.
	^ sm