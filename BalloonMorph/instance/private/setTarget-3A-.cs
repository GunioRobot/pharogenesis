setTarget: aMorph
	(target _ aMorph) ifNotNil: [offsetFromTarget _ self position - target position]