adaptToWorld: aWorld
	super adaptToWorld: aWorld.
	self target: (target adaptedToWorld: aWorld).