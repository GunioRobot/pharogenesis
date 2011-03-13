actorsOutsidePlayfield
	"Note the actors to save that are not in the Playfield"

	notInPlayfield _ OrderedCollection new.
	playfield world submorphs do: [:sub |
		(sub valueOfProperty: #scriptingControl) == true ifFalse:
			[(sub == playfield) | (sub == scaffoldingBook) ifFalse:
				[notInPlayfield add: sub]]].	"save all these"
	^ notInPlayfield