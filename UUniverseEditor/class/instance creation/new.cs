new
	| choice choices |
	choices := UUniverse systemUniverse standardUniverses asArray.
	choices isEmpty ifTrue: [ ^self error: 'no standard universes installed' ].
	choices size = 1 ifTrue: [
		choice _ choices anyOne ]
	ifFalse: [
		| menu |
		menu _
			SelectionMenu
				labels: (choices collect: [ :u | u description ])
				selections: choices.
		choice _ menu startUpWithCaption: 'edit which universe?'.
		choice ifNil: [ ^self ] ].
	
	^self forUniverse: choice