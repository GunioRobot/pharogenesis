registerExternalObject: anObject
	^ ProtectTable critical: [self safelyRegisterExternalObject: anObject]
