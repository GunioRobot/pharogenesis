render: aRenderEngine pickingAt: aPointOrNil withPrimitiveVertex: aBoolean
	"Render one frame of the Wonderland using this camera.
	If aPointOrNil is not nil then pick the top most object at this point.
	For picking only: If aBoolean is true return an association 
	object -> B3DPrimitiveVertex; otherwise simply return the top most object.
	Note: If picking, no objects are actually drawn."
	| aRenderer pickedObject |
	aRenderer _ aRenderEngine. "A couple of things must be set before we can pick!"

	aRenderer viewport: (myMorph bounds insetBy: 1@1).

	(drawSceneBackground)
		ifTrue: [ aRenderer clearViewport: (myWonderland getScene) getColorObject. ]
		ifFalse: [ ].

	aRenderer clearDepthBuffer.
	aRenderer loadIdentity.

	"Add any existing lights to the renderer for this camera"
	(myWonderland getLights) do: [:light | aRenderer addLight: light ].

	"Calculate our view matrix by inverting the camera's composite matrix and hand it
	to the renderer - note that this will eventually have to walk up the tree"
	viewMatrix _ self getMatrixToRoot.
	aRenderer transformBy: viewMatrix.

	aRenderer perspective: perspective.

	"Initialize picking if necessary"
	aPointOrNil == nil
		ifTrue:[	"Record 2D bounds if not picking"
				aRenderer setProperty: #boundsRecorder toValue: self.
				bounds _ IdentityDictionary new: (bounds ifNil:[10] ifNotNil:[bounds size])]
		ifFalse:[	"Make us a picker"
				aRenderer _ aRenderer asPickerAt: aPointOrNil].

	"Now render the scene"
	myWonderland renderWonderland: aRenderer.

	"Force the renderer to draw to the screen"
	aRenderer finish.

	"Fetch the picked object"
	aPointOrNil ifNotNil:[
		aBoolean
			ifTrue:[pickedObject _ aRenderer topMostObject -> aRenderer topMostVertex]
			ifFalse:[pickedObject _ aRenderer topMostObject]].

	aRenderer destroy.

	^pickedObject "Will be nil if not picking"