makeButton: aString balloonText: anotherString for: aSymbol

	self flag: #yo.
	"In principle, this method shouldn't call #translated."

	^ SimpleButtonDelayedMenuMorph new target: self;
		 borderColor: #raised;
		 color: self colorForButtons;
		 label: aString translated font: self fontForButtons;
		 setBalloonText: anotherString translated;
		 actionSelector: aSymbol