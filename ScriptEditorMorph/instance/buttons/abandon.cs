abandon
	owner ifNil: [^ self].
	self isAnonymous  ifTrue:
		[self actuallyDestroyScript.
		"this is destructive but the user has deleted the editor via the halo, making a dialog seemingly inappropriate"].
	self delete