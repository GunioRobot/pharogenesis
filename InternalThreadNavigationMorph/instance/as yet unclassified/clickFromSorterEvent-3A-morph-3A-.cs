clickFromSorterEvent: evt morph: aMorph

	(aMorph bounds containsPoint: evt cursorPoint) ifFalse: [^self].
	evt isMouseUp ifFalse: [
		evt shiftPressed ifFalse: [^evt hand grabMorph: aMorph].
		^self
	].

	evt shiftPressed ifTrue: [
		(Project named: (aMorph valueOfProperty: #nameOfThisProject)) enter.
	].
