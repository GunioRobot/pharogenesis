addHandles
	| handle newVert tri |
	self removeHandles.
	handles _ OrderedCollection new.
	tri _ Array with: 0@-4 with: 4@3 with: -3@3.
	vertices withIndexDo:
		[:vertPt :vertIndex |
		handle _ EllipseMorph newBounds: (Rectangle center: vertPt extent: 8@8)
				color: Color yellow.
		handle on: #mouseMove send: #dragVertex:event:fromHandle:
				to: self withValue: vertIndex.
		handle on: #mouseUp send: #dropVertex:event:fromHandle:
				to: self withValue: vertIndex.
		self addMorph: handle.
		handles addLast: handle.
		(closed or: [vertIndex < vertices size]) ifTrue:
			[newVert _ PolygonMorph
					vertices: (tri collect: [:p | p + (vertPt + (vertices atWrap: vertIndex+1) // 2)])
					color: Color green borderWidth: 1 borderColor: Color black.
			newVert on: #mouseDown send: #newVertex:event:fromHandle:
					to: self withValue: vertIndex.
			self addMorph: newVert.
			handles addLast: newVert]].
	smoothCurve ifTrue: [self updateHandles; layoutChanged].
	self changed