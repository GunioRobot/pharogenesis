addSimpleHandlesTo: aHaloMorph box: aBox
	| aHandle |
	simpleMode _ true.

	target isWorldMorph ifTrue: [^ self addSimpleHandlesForWorldHalos].

	self removeAllMorphs.  "remove old handles, if any"
	
	self bounds: target renderedMorph worldBoundsForHalo.  "update my size"
	
	self addHandleAt: (((aBox topLeft + aBox leftCenter) // 2) + self simpleFudgeOffset) color: Color paleBuff icon: 'Halo-MoreHandles'
		on: #mouseDown send: #addFullHandles to: self.

	aHandle _ self addGraphicalHandle: #Rotate at: aBox bottomLeft on: #mouseDown send: #startRot:with: to: self.
	aHandle on: #mouseMove send: #doRot:with: to: self.

	target isFlexMorph
		ifTrue: [(self addGraphicalHandle: #Scale at: aBox bottomRight  on: #mouseDown send: #startScale:with: to: self)
				on: #mouseMove send: #doScale:with: to: self]
		ifFalse: [(self addGraphicalHandle: #Scale at: aBox bottomRight on: #mouseDown send: #startGrow:with: to: self)
				on: #mouseMove send: #doGrow:with: to: self].

	(innerTarget isMemberOf: SketchMorph) ifTrue:  "isMemberOf: used advisedly here"
		[self addSimpleSketchMorphHandlesInBox: aBox].

	growingOrRotating _ false.
	self layoutChanged.
	self changed.
