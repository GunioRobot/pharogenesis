setActWhen

	| selections |
	selections _ #(mouseDown mouseUp mouseStillDown).
	actWhen _ (SelectionMenu labels: (selections collect: [:t | t translated]) selections: selections)
		startUpWithCaption: 'Choose one of the following conditions' translated
