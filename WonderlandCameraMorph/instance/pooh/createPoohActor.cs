createPoohActor
	| tdo actor |
	outline normalizeTo: 20.
	"outline reduceTo: 80."

	outline _ outline normalizedWithin: self bounds.

	tdo _ POObject createOn: self outline.

	actor _ self getWonderland makeActorNamed: 'pooh'.
	actor setProperty: #handmade toValue: true;
	 setMesh: tdo asB3DSimpleMesh;
	 setColor: brown;
	 setTexturePointer: ((Form extent: 256@128 depth: Display depth) fillColor: Color white) asTexture.

	"actor scaleByMatrix: (B3DMatrix4x4 identity setScale: 0.01@0.01@0.01)."
	actor setComposite: (myCamera getMatrixFromRoot composedWithLocal: (B3DMatrix4x4 withOffset: 0@0@2)).

	self clearStroke.
	Cursor normal beCursor