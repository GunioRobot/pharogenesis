recordMoveObject: objectIndex name: aString depth: depth matrix: matrix colorMatrix: colorMatrix ratio: ratio
	| index oldObj mat |
	index := nil.
	activeMorphs do:[:list|
		list do:[:morph|
			((morph visibleAtFrame: frame-1) and:[
				(morph depthAtFrame: frame-1) = depth])
					ifTrue:[index := morph id]]].
	oldObj := self recordRemoveObject: index depth: depth.
	oldObj isNil ifTrue:[^self].
	objectIndex isNil ifFalse:[index := objectIndex].
	matrix isNil 
		ifTrue:[mat := oldObj matrixAtFrame: frame]
		ifFalse:[mat := matrix].
	self recordPlaceObject: index name: aString depth: depth matrix: mat colorMatrix: colorMatrix ratio: ratio.