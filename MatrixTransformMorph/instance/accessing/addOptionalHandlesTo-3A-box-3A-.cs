addOptionalHandlesTo: aHalo box: box
	aHalo addHandleAt: self referencePosition color: Color lightGray icon: nil on: #mouseMove send: #changeRotationCenter:with: to: self