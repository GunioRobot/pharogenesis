from3DS: aDictionary
	"Remove the globals from the scene - the remaining objects are
	name->sceneObject "
	| globals constants ambient texture funkyNormals r1 |
	globals _ aDictionary at: #globals.
	constants _ globals at: #constants ifAbsent: [Dictionary new].
	aDictionary removeKey: #globals.
	"Collect the scene objects and assign the names"
	objects _ OrderedCollection new.
	aDictionary associationsDo: [:assoc | objects add: ((B3DSceneObject
from3DS: assoc value)
				name: assoc key)].
	"Fetch the cameras and set a default camera"
	cameras _ globals at: #cameras.
	cameras isEmpty
		ifTrue: [defaultCamera _ B3DCamera new position: 0 @ 0 @ 0]
		ifFalse: [defaultCamera _ cameras at: cameras keys
asSortedCollection first].
	"Fetch the lights"
	lights _ globals at: #lights.
	"Add the ambient light if possible.
	Note: The name $AMBIENT$ is used in the keyframe section of the 3DS
	file. "
	ambient _ constants at: 'ambientColor'
				ifAbsent: [B3DColor4
						r: 0.0
						g: 0.0
						b: 0.0
						a: 0.0].
	ambient ifNotNil: [lights at: '$AMBIENT$' put: (B3DAmbientLight
color: ambient)].
	"Fetch the background color"
	clearColor _ constants at: 'backgroundColor' ifAbsent: [Color white].
	"Fetch the materials and replace names in sceneObjects by actual
	materials "
	materials _ globals at: #materials.
	"Compute the per vertex normals"
	funkyNormals _ self confirm: 'Do you want funky normals instead of
accurate normals?
(It will give the model a somewhat strange, but interesting look)'.
	'Computing vertex normals'
		displayProgressAt: Sensor cursorPoint
		from: 0
		to: objects size
		during: [:bar | objects
				doWithIndex:
					[:obj :index |
					bar value: index.
					obj material ifNotNil: [obj
material: (materials at: obj material ifAbsent: [])].
					funkyNormals
						ifTrue: [obj geometry
computeFunkyVertexNormals]
						ifFalse: [obj geometry
vertexNormals]]].
	(self confirm: 'Do you want to use a texture with the model?')
		ifTrue:
			[Utilities informUser: 'Choose a rectangle with
interesting stuff'
				during:
					[r1 _ Rectangle originFromUser: 128
@ 128.
					Sensor waitNoButton].
			texture _ B3DTexture fromDisplay: r1.
			texture wrap: true.
			texture interpolate: false.
			texture envMode: 0].
	objects do: [:obj | obj texture ifNotNil: [obj texture: texture]]