buildMorphicOutBoxStatusPaneFor: model 
	| v |
	v := PluggableTextMorph new
		on: model
		text: #outBoxStatus
		accept: nil
		readSelection: nil
		menu: nil.
	v borderWidth: 1.
	^v