actorMenu: aMenu
	"Builds the menu to display when the user right clicks on an actor"

 	selectedActor ifNil: [ ^ aMenu ].

	(selectedActor isKindOf: WonderlandScene)
		ifTrue: [ ^ aMenu addList: { { 'Load actor'. #loadActor } } ].

	(selectedActor isFirstClass)
		ifTrue: [
			^ aMenu addList: {
								{'Point camera at'. #pointAt}.
								{'Turn around once'. #turnAround}.
								{'Become part'. #becomePart }.
								{'Stand up'. #standUp}.
								{'Grow'. #grow}.
								{'Shrink'. #shrink}.
								{'Squash'. #squash}.
								{'Stretch'. #stretch}.
								{'Destroy'. #destroy}
							  }.
				]
		ifFalse: [
			^ aMenu addList: {
								{'Point camera at'. #pointAt}.
								{'Turn around once'. #turnAround}.
								{'Become first class'. #becomeFirstClass }.
								{'Stand up'. #standUp}.
								{'Grow'. #grow}.
								{'Shrink'. #shrink}.
								{'Squash'. #squash}.
								{'Stretch'. #stretch}.
								{'Destroy'. #destroy}
							  }.
				].
