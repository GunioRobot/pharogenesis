balloonHelpTextForHandle: aHandle
	|  itsSelector |
	itsSelector _ aHandle eventHandler firstMouseSelector.
	#(	(rotateStartFromHalo:with:				'Rotate')
		(growStartFromHalo:with:				'Change size') 
		(dupStartFromHalo:with:					'Duplicate')
		(grabFromHalo:with:						'Pick up')
		(dragStartFromHalo:with:				'Move')
		(extractTexture:							'Extract texture')
		(paintTexture							'Paint on surface')
	) do:
		[:pair | itsSelector == pair first ifTrue: [^ pair last]].
	^super balloonHelpTextForHandle: aHandle