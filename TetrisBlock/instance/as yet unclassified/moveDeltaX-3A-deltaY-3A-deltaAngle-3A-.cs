moveDeltaX: deltaX deltaY: deltaY deltaAngle: deltaAngle 

	| delta |

	delta _ deltaX @ deltaY.
	(shapeInfo atWrap: angle + deltaAngle) do: [ :offsetThisCell | 
		(board emptyAt: baseCellNumber + offsetThisCell + delta) ifFalse: [^ false]
	].
	baseCellNumber _ baseCellNumber + delta.
	angle _ angle + deltaAngle - 1 \\ 4 + 1.
	self positionCellMorphs.
	^ true 