on: anObject text: getTextSel accept: setTextSel readSelection: getSelectionSel menu: getMenuSel
	|styler answer|
	answer := self new.
	styler := SHTextStylerST80 new
		view: answer;
		yourself.
	^ answer 
		styler: styler;
		on: anObject
		text: getTextSel
		accept: setTextSel
		readSelection: getSelectionSel
		menu: getMenuSel