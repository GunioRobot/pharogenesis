setActWhen

	| selections |
	selections := #(mouseDown mouseUp mouseStillDown).
	actWhen := (SelectionMenu labels: (selections collect: [:t | t translated]) selections: selections)
		startUpWithCaption: 'Choose one of the following conditions' translated
