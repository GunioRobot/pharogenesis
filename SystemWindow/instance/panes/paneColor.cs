paneColor
	| cc |
	(cc := self valueOfProperty: #paneColor) ifNotNil: [^cc].
	Display depth > 2 
		ifTrue: 
			[model ifNotNil: 
					[model isInMemory 
						ifTrue: 
							[cc := Color colorFrom: model defaultBackgroundColor.
							Preferences alternativeWindowLook 
								ifTrue: 
									[cc := (cc = Color lightYellow or: [cc = Color white]) 
										ifTrue: [Color gray: 0.67]
										ifFalse: [cc duller]]]].
			cc 
				ifNil: [cc := paneMorphs isEmptyOrNil ifFalse: [paneMorphs first color]]].
	cc ifNil: [cc := self defaultBackgroundColor].
	self paneColor: cc.
	^cc