asIndexedTriangleMesh
	"Convert the receiver into (the more compact) indexed triangle representation"
	| map faces face vtx nrm tex col mesh |
	map _ Dictionary new: (self size * 4). "Need some space for the vertices"
	faces _ WriteStream on: (B3DIndexedTriangleArray new: self size).
	self trianglesDo:[:tri|
		tri assureVertexNormals.
		face _ B3DIndexedTriangle
					with: (map at: tri first ifAbsentPut:[map size + 1])
					with: (map at: tri second ifAbsentPut:[map size + 1])
					with: (map at: tri third ifAbsentPut:[map size + 1]).
		faces nextPut: face].
	faces _ faces contents.
	vtx _ B3DVector3Array new: map size.
	nrm _ B3DVector3Array new: map size.
	self hasTextureCoords ifTrue:[tex _ B3DTexture2Array new: map size].
	self hasVertexColors ifTrue:[col _ B3DColor4Array new: map size].
	map keysAndValuesDo:[:vertex :idx|
		vtx at: idx put: vertex position.
		nrm at: idx put: vertex normal.
		tex == nil ifFalse:[tex at: idx put: vertex texCoord].
		col == nil ifFalse:[col at: idx put: vertex color].
	].
	mesh _ B3DIndexedTriangleMesh new.
	mesh faces: faces.
	mesh vertices: vtx.
	mesh texCoords: tex.
	mesh vertexColors: col.
	mesh vertexNormals: nrm.
	^mesh