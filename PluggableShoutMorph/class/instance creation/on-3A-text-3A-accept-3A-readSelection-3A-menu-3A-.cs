on: anObject text: getTextSel accept: setTextSel readSelection: getSelectionSel menu: getMenuSel
	|styler answer |
	answer := self new.
	styler := SHTextStylerST80 new
		view: answer;
		yourself.
	"styler when: #aboutToStyle send: #shoutStylerAboutToStyle: to: anObject with: styler."
	^ answer
		styler: styler;
		on: anObject
		text: getTextSel
		accept: setTextSel
		readSelection: getSelectionSel
		menu: getMenuSel