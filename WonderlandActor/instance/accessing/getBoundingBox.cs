getBoundingBox
	"Returns the actor's bounding box"

	| size x y z nOrigin nCorner childBBox cOrigin cCorner meshBBox mOrigin mCorner |

	(myMesh notNil)
		ifTrue: [ meshBBox _ myMesh boundingBox.
true ifTrue:[
				cOrigin _ scaleMatrix localPointToGlobal: meshBBox origin.
				cCorner _ scaleMatrix localPointToGlobal: meshBBox corner.
				nOrigin _ cOrigin min: cCorner.
				nCorner _ cOrigin max: cCorner.
] ifFalse:[
				 size _ self getSizeVector.
				 mOrigin _ meshBBox origin.
				 mCorner _ meshBBox corner.

				 x _ (mOrigin x) * (size x).
				 y _ (mOrigin y) * (size y).
				 z _ (mOrigin z) * (size z).
				 nOrigin _ B3DVector3 x: x y: y z: z.

				 x _ (mCorner x) * (size x).
				 y _ (mCorner y) * (size y).
				 z _ (mCorner z) * (size z).
				 nCorner _ B3DVector3 x: x y: y z: z.
].
				]
		ifFalse: [ nOrigin _ (B3DVector3 x:0 y:0 z:0).
				  nCorner _ (B3DVector3 x:0 y:0 z:0) ].


	myChildren do: [:child | 
			(child isPart) ifTrue: [
									childBBox _ child getBoundingBox: self.
				 					cOrigin _ childBBox origin.
				 					cCorner _ childBBox corner.
									nOrigin _ nOrigin min: cOrigin.
									nCorner _ nCorner max: cCorner.
								 ].
					].

	^ Rectangle origin: nOrigin corner: nCorner.
