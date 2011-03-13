createThreadShowing

	| vertices b |
	self deleteThreadShowing.
	vertices _ OrderedCollection new.
	self tileRows do: [:row |
		row first isTurtleRow ifTrue: [
			b _ row first bounds.
			vertices add: ((b topLeft + (4@0)) + ((0 * 0.1 * b width)@0)).
			0 to: 9 do: [:i |
				vertices add: ((b topLeft + (4@4))+ ((i * 0.1 * b width )@0)).
				vertices add: ((b bottomLeft + (4@-4)) + ((i * 0.1 * b width)@0)).
			].	
			vertices add: ((b bottomLeft + (4@0)) + ((9 * 0.1 * b width)@0)).
		] ifFalse: [
			b _ row first bounds.
			vertices add: ((b origin x + b corner x)//2)@(b origin y).
			vertices add: ((b origin x + b corner x)//2)@(b origin y + 4).
			vertices add: ((b origin x + b corner x)//2)@(b corner y - 4).
			vertices add: ((b origin x + b corner x)//2)@(b corner y).
		].
	].
	threadPolygon _ PolygonMorph vertices: vertices color: Color black borderWidth: 2 borderColor: Color black.
	threadPolygon makeOpen.
	threadPolygon openInWorld.
