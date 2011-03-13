newMouseFocus: aMorph event: event
	aMorph == nil ifFalse:[
		targetOffset _ event cursorPoint - aMorph position.
	].
	^self newMouseFocus: aMorph.
