textStyleFrom: fontName sizes: ptSizes
	| styleName fonts |
	styleName _ fontName asSymbol.
	(TextConstants includesKey: styleName)
		ifTrue:[(self confirm: 
styleName , ' is already defined in TextConstants.
Do you want to replace that definition?')
			ifFalse: [^ self]].
	('Rendering ', styleName) displayProgressAt: Sensor cursorPoint
		from: 1 to: ptSizes size during:[:bar|
			fonts _ ptSizes
				collect:[:ptSize| bar value: (ptSizes indexOf: ptSize).
							   self fontName: styleName 
									size: ptSize
									emphasis: 0]
				thenSelect:[:font| font notNil]]. "reject those that failed"
	fonts size = 0 ifTrue:[^self error:'Could not create font style', styleName].
	TextConstants
		at: styleName
		put: (TextStyle fontArray: fonts).