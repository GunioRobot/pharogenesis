initialize
	"Initialize this morph"

	super initialize.

	updatingIsOn _ false.

	self name: 'Actor Info'.
	self extent: 500@350.
	self color: (Color r: 0.815 g: 0.972 b: 0.878).

	dataMorph _ WonderlandActorData new.
	self addMorph: dataMorph.
	dataMorph topLeft: 200@10.
