containsPoint: aPoint
	(bounds containsPoint: aPoint) ifFalse: [^ false].
	self hasSubmorphs
		ifTrue: [self submorphsDo: 
					[:m | (m containsPoint: (transform globalPointToLocal: aPoint))
							ifTrue: [^ true]].
				^ false]
		ifFalse: [^ true]