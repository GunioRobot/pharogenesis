recordButton: id trackAsMenu: aBoolean
	| button |
	button := buttons at: id ifAbsent:[^self halt].
	button trackAsMenu: aBoolean.
