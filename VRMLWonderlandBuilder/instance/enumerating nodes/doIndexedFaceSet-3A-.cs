doIndexedFaceSet: node
	| attr faces points mesh |
	attributes at: #currentPoints put: nil.
	(attr _ node attributeValueNamed: 'coord') notNil
		ifTrue:[attr doWith: self].
	points _ attributes at: #currentPoints.
	points ifNil:[^self].
	(attr _ node attributeValueNamed: 'coordIndex') notNil
		ifTrue:[faces _ self facesFrom: attr for: points].
	faces ifNil:[^self].
	mesh _ B3DSimpleMesh withAll: faces.
	self assignIndexedNormals: node in: mesh.
	self assignIndexedTexCoords: node in: mesh.
	self assignIndexedColors: node in: mesh.
	mesh _ mesh asIndexedTriangleMesh.
	"Try to recycle the actors"
	(currentActor == nil or:[currentActor hasMesh])
		ifTrue:[self createActorFor: mesh]
		ifFalse:[	currentActor setMesh: mesh.
				attributes at: #currentShape put: currentActor].