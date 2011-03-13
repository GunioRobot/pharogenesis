repelsMorph: aMorph event: ev

	(showingMethodPane == true and: 
		[self world valueOfProperty: #universalTiles ifAbsent: [false]]) ifTrue: [
			^ (aMorph respondsTo: #parseNode) not].

	^ aMorph isTileLike not