handlesMouseOver: evt
	"Could just ^ true, but this ensures that scroll bars won't flop out
	if you mouse-over appendages such as connecting pins."

	| cp |
	cp _ evt cursorPoint.
	(bounds containsPoint: cp)
		ifTrue: [^ true]			
		ifFalse: [self submorphsDo:
					[:m | (m containsPoint: cp) ifTrue:
							[m == scrollBar
								ifTrue: [^ true]
								ifFalse: [^ false]]].
				^ false]