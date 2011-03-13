soundNameFromUser
	"Obtain a sound from the user.  Exclude the items designated as being discouraged, except that if the current selection is one of those, show it anyway"

	| choices |
	choices := self soundChoices.
	^ (SelectionMenu labels: (choices collect: [:t | t translated]) selections: self soundChoices) startUpWithCaption: 'Sounds' translated