editHistory
	editHistory ifNil: [ editHistory := TextMorphCommandHistory new].
	^editHistory
