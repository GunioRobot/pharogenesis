push: aButton
	| index |
	index _ buttons indexOf: aButton.
	model perform: setSelectionSelector with: index.