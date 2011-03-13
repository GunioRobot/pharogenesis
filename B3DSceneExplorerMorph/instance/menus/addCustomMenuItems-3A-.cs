addCustomMenuItems: aCustomMenu

	(aCustomMenu isKindOf: MenuMorph)
		ifTrue: [aCustomMenu addUpdating: #rotationString action: #switchRotationStatus]
		ifFalse: [aCustomMenu add: 'swich rotation status' action: #switchRotationStatus].
	(aCustomMenu isKindOf: MenuMorph)
		ifTrue: [aCustomMenu addUpdating: #headLightString action: #switchHeadLightStatus]
		ifFalse: [aCustomMenu add: 'swich headlight' action: #switchHeadLightStatus].
	aCustomMenu add: 'open 3DS file' action: #openThreeDSFile.
	aCustomMenu add: 'select new camera' action: #selectNewCamera.