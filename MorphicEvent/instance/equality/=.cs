= aMorphicEvent

	(aMorphicEvent isKindOf: self class) ifFalse: [^ false].
	type = aMorphicEvent type ifFalse: [^ false].
	cursorPoint = aMorphicEvent cursorPoint ifFalse: [^ false].
	buttons = aMorphicEvent buttons ifFalse: [^ false].
	keyValue = aMorphicEvent keyValue ifFalse: [^ false].
	^ true
