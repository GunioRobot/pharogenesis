setActWhen

	| selections |
	selections _ #(buttonDown buttonUp whilePressed startDrag).
	actWhen := (SelectionMenu 
				labels: (selections collect: [:t | t translated]) selections: selections) 
					startUpWithCaption: 'Choose one of the following conditions' translated