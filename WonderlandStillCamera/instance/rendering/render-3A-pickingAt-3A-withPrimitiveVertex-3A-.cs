render: aRenderEngine pickingAt: aPointOrNil withPrimitiveVertex: aBoolean
	"Override the parent method. A WonderlandStillCamera only renders the object that it's focusing on."

	| aRenderer pickedObject |
	aRenderer _ aRenderEngine. "A couple of things must be set before we can pick!"

	aRenderer viewport: (myMorph bounds insetBy: 1@1).

	(drawSceneBackground)
		ifTrue: [ aRenderer clearViewport: (myWonderland getScene getColorObject). ]
		ifFalse: [ ].

	aRenderer clearDepthBuffer.
	aRenderer loadIdentity.

	focusObject ifNotNil: [

		"Add any existing lights to the renderer for this camera"
		(myWonderland getLights) do: [:light | aRenderer addLight: light ].

		"Calculate our view matrix by inverting the camera's composite matrix and hand it
		to the renderer - note that this will eventually have to walk up the tree"
		viewMatrix _ self getMatrixToRoot.
		aRenderer transformBy: viewMatrix.

		aRenderer perspective: perspective.

		"Initialize picking if necessary"
		aPointOrNil ifNotNil:[aRenderer _ aRenderer asPickerAt: aPointOrNil].

		(focusObject isKindOf: WonderlandScene)
			ifTrue: [ myWonderland renderWonderland: aRenderer ]
			ifFalse: [ aRenderer transformBy: (focusObject getParent getMatrixFromRoot).
					  focusObject renderOn: aRenderer ].

		"Fetch the picked object"
		aPointOrNil ifNotNil:[
			aBoolean
				ifTrue:[pickedObject _ aRenderer topMostObject -> aRenderer topMostVertex]
				ifFalse:[pickedObject _ aRenderer topMostObject]].

	].

	"Force the renderer to draw to the screen"
	aRenderer finish.

	aRenderer destroy.

	^pickedObject "Will be nil if not picking".
