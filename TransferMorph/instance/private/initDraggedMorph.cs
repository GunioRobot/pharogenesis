initDraggedMorph
	| plusMorph |
	draggedMorph ifNil: [
		draggedMorph _ self passenger asDraggableMorph.
		self shouldCopy ifTrue: [
			plusMorph _ ImageMorph new image: CopyPlusIcon.
			draggedMorph addMorph: plusMorph.
			plusMorph position: plusMorph width negated@0].
		draggedMorph position: self position.
		self extent: (draggedMorph fullBounds extent + (6@6)).
		draggedMorph align: draggedMorph topLeft with: (self topLeft + (3@3)).
		self addMorph: draggedMorph]