textStyleFrom: fontName
	"HostFont textStyleFromUser"
	| styleName fonts |
	styleName _ fontName asSymbol.
	"(TextConstants includesKey: styleName)
		ifTrue:[(self confirm: 
styleName , ' is already defined in TextConstants.
Do you want to replace that definition?')
			ifFalse: [^ self]]."
	fonts _ #(10 11 12 13 14 16 18 20 22 24 26 28 30 36 48 60 72 90).
	('Rendering ', styleName) displayProgressAt: Sensor cursorPoint
		from: 1 to: fonts size during:[:bar|
			fonts _ fonts
				collect:[:ptSize| bar value: (fonts indexOf: ptSize).
							   self fontName: styleName 
									size: ptSize
									emphasis: 0]
				thenSelect:[:font| font notNil]]. "reject those that failed"
	fonts size = 0 ifTrue:[^self error:'Could not create font style', styleName].
	TextConstants
		at: styleName
		put: (TextStyle fontArray: fonts).