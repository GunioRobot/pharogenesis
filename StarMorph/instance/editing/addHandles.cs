addHandles
	| center | 
	self removeHandles.
	center _ vertices sum // vertices size.   "Average vertices to get the center"
	handles _ {center. vertices second} with: {#center. #outside} collect:
		[:p :which | (EllipseMorph newBounds: (Rectangle center: p extent: 8@8)
							color: Color yellow)
				on: #mouseDown send: #dragVertex:event:fromHandle:
						to: self withValue: which;
				on: #mouseMove send: #dragVertex:event:fromHandle:
						to: self withValue: which].
	self addAllMorphs: handles.
	self changed