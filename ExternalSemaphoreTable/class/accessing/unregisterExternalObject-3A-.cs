unregisterExternalObject: anObject
	ProtectTable critical: [self safelyUnregisterExternalObject: anObject]
