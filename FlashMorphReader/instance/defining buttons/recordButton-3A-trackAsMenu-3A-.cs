recordButton: id trackAsMenu: aBoolean
	| button |
	button _ buttons at: id ifAbsent:[^self halt].
	button trackAsMenu: aBoolean.
