initialize
	"Initialize this morph by setting up the various submorphs to be able to show data about a WonderlandActor"

	| aMorph |

	super initialize.
	self color: (Color r: 0.815 g: 0.972 b: 0.878).
	self bounds: (0@0 corner: 300@120).

	nameMorph _ TextMorph new.
	nameMorph contents: 'Name: (No actor selected)'.
	nameMorph topLeft: 10@10.
	self addMorph: nameMorph.

	parentMorph _ TextMorph new.
	parentMorph contents: 'Parent: '.
	parentMorph topLeft: 10@25.
	self addMorph: parentMorph.

	aMorph _ TextMorph new.
	aMorph contents: 'Position relative to parent'.
	aMorph topLeft: 10@55.
	self addMorph: aMorph.

	positionMorph _ TextMorph new.
	positionMorph contents: ((Character tab) asString) , 'Right:    Up:    Forward: '.
	positionMorph topLeft: 10@70.
	self addMorph: positionMorph.

	aMorph _ TextMorph new.
	aMorph contents: 'Rotation about'.
	aMorph topLeft: 10@100.
	self addMorph: aMorph.

	rotationMorph _ TextMorph new.
	rotationMorph contents: ((Character tab) asString) , 'Left-Right axis: ' ,
				((Character cr) asString) , ((Character tab) asString) , 'Up-Down axis: ',
				((Character cr) asString) , ((Character tab) asString) , 'Forward-Back axis: '.
	rotationMorph topLeft: 10@115.
	self addMorph: rotationMorph.

