acceptDroppingMorph: aMorph event: evt

	| m |
	m _ self owner.
	[m == nil] whileFalse: [
		self flag: #priorityFix.
		self flag: #arNote. "What the @#$% is this????????"
		((m respondsTo: #orientation) and: [m orientation == #vertical]) ifTrue: [^ m acceptDroppingMorph: aMorph event: evt].
		m _ m owner].

	"| o |
	self prepareToUndoDropOf: aMorph.
	o _ owner.
	self delete.
	aMorph position: o position.
	o addMorph: aMorph."