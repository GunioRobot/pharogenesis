setActWhen

	| selections |
	selections _ #(buttonDown buttonUp whilePressed).
	actWhen _ (SelectionMenu labelList: (selections collect: [:t | t translated]) selections: selections)
		startUpWithCaption: 'Choose one of the following conditions' translated.
