makeActorFrom3DS: filename
	"Creates a new actor using the specification from the given file"

	| parent name baseActor newActor actorClass scene globals hierarchy meshSize materials material textureName cameras newCamera |

	myUndoStack closeStack.

	scene _ ThreeDSParser parseFileNamed: filename.
	scene ifNil:[^nil].
	globals _ scene at: #globals.
	materials _ globals at: #materials ifAbsent:[Dictionary new].
	"The remaining objects are the actual named meshes,"
	scene removeKey: #globals.
	hierarchy _ self createHierarchyFrom3DS: globals.

	baseActor _ self makeBaseActorFrom: filename.

	"Now create the actors"
	scene associationsDo:[:assoc|
		name _ assoc key.
		actorClass _ WonderlandActor newUniqueClassInstVars: '' classInstVars: ''.
		newActor _ actorClass createFor: self.
		actorClassList addLast: actorClass.
		newActor setName: (self fixNameFrom: name).
		"newActor setTexture: texture."
		newActor setMesh: (B3DSTriangleMesh from3DS: assoc value).
		material _ materials at: (assoc value at: #triList) last ifAbsent:[nil].
		(material isKindOf: Association) ifTrue:[
			"Note: In this case the name of the texture is the key"
			textureName _ material key.
			material _ material value].
		newActor setMaterial: material.
		"newActor setComposite: matrix."
		assoc value: newActor.
	].

	"Create hierarchy"
	scene associationsDo:[:assoc|
		name _ assoc key.
		newActor _ assoc value.
		newActor setName: (self uniqueNameFrom: name).
		parent _ hierarchy at: name ifAbsent:[nil].
		parent == nil ifFalse:[parent _ scene at: parent ifAbsent:[nil]].
		parent == nil ifTrue:[parent _ baseActor].
		newActor reparentTo: parent.
		newActor becomePart.
	].

	"Create the cameras"
	cameras _ globals at: #cameras.
	cameras associationsDo:[:assoc|
		name _ assoc key.
		newCamera _ WonderlandCamera createFor: self.
		newCamera getMorph openInWorld.
		newCamera setName: (self fixNameFrom: name).
		newCamera copySettingsFrom: assoc value.
		newCamera reparentTo: baseActor.
		newCamera becomePart.
	].

	meshSize _ baseActor getBoundingBox extent length.
	meshSize > 100.0 ifTrue:[
		(self inform:'This actor is huge!
You should rescale it to a reasonable size.')].
	meshSize < 0.01 ifTrue:[
		self inform:'This actor is tiny!
You should rescale it to a reasonable size.'].
		
	myUndoStack openStack.

	"Ensure that the new actor's name is unique"
	myNamespace at: baseActor getName put: baseActor.
	scriptEditor updateActorBrowser.

	"Add an undo item to undo the creation of this object"
	myUndoStack push: (UndoAction new: [ baseActor removeFromScene.
											myNamespace removeKey: baseActor getName ifAbsent: [].
											scriptEditor updateActorBrowser.  ] ).

	^ baseActor.
