doIndexedFaceSet: node
	| attr faces points mesh ipPoints meshList map |
	attributes at: #currentPoints put: nil.
	(attr _ node attributeValueNamed: 'coord') notNil
		ifTrue:[attr doWith: self].
	points _ attributes at: #currentPoints.
	ipPoints _ attributes at: #interpolatorPoints ifAbsent:[nil].
	points ifNil:[^self].
	(attr _ node attributeValueNamed: 'coordIndex') notNil
		ifTrue:[faces _ self facesFrom: attr for: points].
	faces ifNil:[^self].
	mesh _ B3DSimpleMesh withAll: faces.
	self assignIndexedNormals: node in: mesh.
	self assignIndexedTexCoords: node in: mesh.
	self assignIndexedColors: node in: mesh.
	mesh _ mesh asIndexedTriangleMesh.
	ipPoints == nil ifFalse:[
		"Re-map points for interpolated meshes"
		map _ Dictionary new: points size * 2.
		points doWithIndex:[:pt :index| map at: pt put: index].
		meshList _ ipPoints collect:[:pts|
			mesh clone vertices: (mesh vertices collect:[:pt| pts at: (map at: pt)])].
		mesh _ B3DInterpolatedMesh new initialize meshes: meshList.
	].
	"Try to recycle the actors"
	(currentActor == nil or:[currentActor hasMesh])
		ifTrue:[self createActorFor: mesh]
		ifFalse:[	currentActor setMesh: mesh.
				attributes at: #currentShape put: currentActor].