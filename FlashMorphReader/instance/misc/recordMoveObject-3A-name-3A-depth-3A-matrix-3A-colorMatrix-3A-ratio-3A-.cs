recordMoveObject: objectIndex name: aString depth: depth matrix: matrix colorMatrix: colorMatrix ratio: ratio
	| index oldObj mat |
	index _ nil.
	activeMorphs do:[:list|
		list do:[:morph|
			((morph visibleAtFrame: frame-1) and:[
				(morph depthAtFrame: frame-1) = depth])
					ifTrue:[index _ morph id]]].
	oldObj _ self recordRemoveObject: index depth: depth.
	oldObj isNil ifTrue:[^self].
	objectIndex isNil ifFalse:[index _ objectIndex].
	matrix isNil 
		ifTrue:[mat _ oldObj matrixAtFrame: frame]
		ifFalse:[mat _ matrix].
	self recordPlaceObject: index name: aString depth: depth matrix: mat colorMatrix: colorMatrix ratio: ratio.