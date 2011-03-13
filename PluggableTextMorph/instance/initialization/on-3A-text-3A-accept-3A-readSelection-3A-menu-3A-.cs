on: anObject text: getTextSel accept: setTextSel readSelection: getSelectionSel menu: getMenuSel

	self model: anObject.
	getTextSelector _ getTextSel.
	setTextSelector _ setTextSel.
	getSelectionSelector _ getSelectionSel.
	getMenuSelector _ getMenuSel.
	self borderWidth: 1.
	self setText: self getText.
	self setSelection: self getSelection.