findNextAETEdgeFrom: leftEdge
	| depth rightEdge |
	depth _ self edgeZValueOf: leftEdge.
	[self aetStartGet < self aetUsedGet] whileTrue:[
		rightEdge _ aetBuffer at: self aetStartGet.
		(self edgeZValueOf: rightEdge) >= depth ifTrue:[^rightEdge].
		self aetStartPut: self aetStartGet + 1.
	].
	^nil