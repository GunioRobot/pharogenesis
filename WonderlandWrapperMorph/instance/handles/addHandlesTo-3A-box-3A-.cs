addHandlesTo: aHaloMorph box: box
	| dismissHandle s |
	s _ aHaloMorph handleSize.
	myActor getTexturePointer == nil ifFalse:[
		aHaloMorph addHandleAt: box rightCenter color: Color lightGray on: #mouseDown send: #extractTexture: to: aHaloMorph target].

	aHaloMorph addHandleAt: box topLeft color: Color red icon: 'Halo-Menu'
		on: #mouseDown send: #doMenu:with: to: aHaloMorph.

	aHaloMorph addHandleAt: (box leftCenter + (0 @ (s+2)) min: box leftCenter + box bottomLeft // 2)
		color: Color lightBrown icon: 'Halo-Tile'
		on: #mouseDown send: #tearOffTile to: self.

	dismissHandle _ aHaloMorph addHandleAt: (box topLeft + ((s+2)@0) min: box topLeft + box topCenter // 2)
		color: Color red muchLighter icon: 'Halo-Dismiss'
		on: #mouseDown send: #mouseDownInDimissHandle:with: to: aHaloMorph.
	dismissHandle on: #mouseUp send: #maybeDismiss:with: to: aHaloMorph.
	dismissHandle on: #mouseDown send: #setDismissColor:with: to: aHaloMorph.
	dismissHandle on: #mouseMove send: #setDismissColor:with: to: aHaloMorph.

	aHaloMorph addHandleAt: box leftCenter color: Color cyan icon: 'Halo-View'
		on: #mouseDown send: #openViewerForArgument to: self.

	aHaloMorph addHandleAt: box topCenter color: Color black icon: 'Halo-Grab'
		on: #mouseDown send: #grabFromHalo:with: to: self.

	(aHaloMorph addHandleAt: (box topCenter + ((s+2)@0) min: box topCenter + box topRight // 2)
		color: Color brown icon: 'Halo-Drag'
		on: #mouseDown send: #dragStartFromHalo:with: to: self)
		on: #mouseMove send: #dragMoveFromHalo:with: to: self;
		on: #mouseUp send: #dragEndFromHalo:with: to: self.

	(aHaloMorph addHandleAt: box topRight color: Color green icon: 'Halo-Dup'
		on: #mouseDown send: #dupStartFromHalo:with: to: self)
		on: #mouseMove send: #dupMoveFromHalo:with: to: self;
		on: #mouseUp send: #dupEndFromHalo:with: to: self.

	Preferences showDebugHaloHandle ifTrue:
		[aHaloMorph addHandleAt: ((box topRight + box rightCenter) // 2)
			color: Color blue veryMuchLighter icon: 'Halo-Debug'
			on: #mouseDown send: #doDebug:with: to: aHaloMorph].

	(aHaloMorph addHandleAt: box bottomLeft color: Color blue icon: 'Halo-Rotate'
		on: #mouseDown send: #rotateStartFromHalo:with: to: self)
		on: #mouseMove send: #rotateMoveFromHalo:with: to: self;
		on: #mouseUp send: #rotateEndFromHalo:with: to: self.

	(aHaloMorph addHandleAt: box bottomRight color: Color yellow icon: 'Halo-Scale'
		on: #mouseDown send: #growStartFromHalo:with: to: self)
		on: #mouseMove send: #growMoveFromHalo:with: to: self;
		on: #mouseUp send: #growEndFromHalo:with: to: self.

	myActor isHandmade
		ifTrue: [
			(aHaloMorph addHandleAt: box center color: Color white icon: 'Halo-Paint'
				on: #mouseUp send: #paintTexture to: self)]

