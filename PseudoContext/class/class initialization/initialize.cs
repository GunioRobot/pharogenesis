initialize
	"It's tricky to do the necessary stuff with the regular file-in machinery."

	PseudoContext superclass = nil
		ifFalse: [
			(Smalltalk confirm: 'Shall I convert PseudoContext into a compact subclass of nil?
("yes" is almost always the correct response)')
				ifTrue: [
					PseudoContext becomeCompact.
					PseudoContext superclass removeSubclass: PseudoContext.
					PseudoContext superclass: nil]].
	Smalltalk recreateSpecialObjectsArray.
	Smalltalk specialObjectsArray size = 41
		ifFalse: [self error: 'Please check size of special objects array!']