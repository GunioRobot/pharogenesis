addCustomMenuItems: aCustomMenu

	(aCustomMenu isKindOf: MenuMorph)
		ifTrue: [aCustomMenu addUpdating: #rotationString action: #switchRotationStatus]
		ifFalse: [aCustomMenu add: 'swich rotation status' action: #switchRotationStatus].
