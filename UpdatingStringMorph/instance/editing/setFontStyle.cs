setFontStyle
	| aList reply style |
	aList := (TextConstants select: [:anItem | anItem isKindOf: TextStyle]) 
				keys asOrderedCollection.
	reply := (SelectionMenu labelList: aList selections: aList) startUp.
	reply notNil 
		ifTrue: 
			[(style := TextStyle named: reply) ifNil: 
					[Beeper beep.
					^true].
			self font: style defaultFont]