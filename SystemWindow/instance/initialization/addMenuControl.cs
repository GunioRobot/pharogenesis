addMenuControl
"NB: for the moment, we always supply balloon help for this control, until people get used to it; eventually, we mays switch to showing this balloon help only in novice mode, as we do for the other standard window controls."
	| frame |
	menuBox _ IconicButton new borderWidth: 0;
			labelGraphic: (ScriptingSystem formAtKey: 'TinyMenu'); color: Color transparent; 
			actWhen: #buttonDown;
			actionSelector: #offerWindowMenu; target: self;
			setBalloonText: 'window menu'.
	frame _ LayoutFrame new.
	frame leftFraction: 0; leftOffset: 19; topFraction: 0; topOffset: 1.
	menuBox layoutFrame: frame.
	labelArea addMorph: menuBox.

