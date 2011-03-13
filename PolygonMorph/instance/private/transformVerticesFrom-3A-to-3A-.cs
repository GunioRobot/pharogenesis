transformVerticesFrom: oldOwner to: newOwner
	| oldTransform newTransform world newVertices |
	world _ self world.
	oldTransform _ oldOwner
		ifNil: [ IdentityTransform new ]
		ifNotNil: [ oldOwner transformFrom: world ].
	newTransform _ newOwner
		ifNil: [ IdentityTransform new ]
		ifNotNil: [ newOwner transformFrom: world ].
	newVertices _ vertices collect: [ :ea | newTransform globalPointToLocal:
		(oldTransform localPointToGlobal: ea) ].
	self setVertices: newVertices.
