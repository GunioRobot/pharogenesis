activate
	(Smalltalk includesKey: #Celeste)
		ifFalse: [^ self notify: 'no mail reader present'].
	^ CelesteComposition
		openForCeleste: Celeste current
		initialText: self composeText