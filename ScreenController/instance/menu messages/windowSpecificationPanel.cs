windowSpecificationPanel
	Smalltalk hasMorphic ifFalse:
		[^ self inform: 'Sorry, this feature requires the presence of Morphic.'].
	Preferences windowSpecificationPanel