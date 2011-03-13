= aVersion
	components size = aVersion components size ifFalse:[ ^false ].

	components with: aVersion components do: [ :myComp :itsComp |
		(myComp uversionEqual: itsComp) ifFalse: [
			^false ] ].
	
	^true