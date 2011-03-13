select: aNode
	(self announce: OBAboutToChange)
		isVetoed ifFalse: [self announce: (OBSelectingNode node: aNode)]