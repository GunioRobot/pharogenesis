addOptionalHandlesTo: aHalo box: box
	aHalo addHandleAt: self referencePosition color: Color lightGray icon: nil on: #mouseStillDown send: #changeRotationCenter:with: to: self