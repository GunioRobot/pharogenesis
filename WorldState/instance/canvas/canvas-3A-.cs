canvas: x

	canvas _ x.
	damageRecorder == nil
		ifTrue: [damageRecorder _ DamageRecorder new]
		ifFalse: [damageRecorder doFullRepaint]