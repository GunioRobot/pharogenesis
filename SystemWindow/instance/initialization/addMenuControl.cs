addMenuControl
	self addMorph: (menuBox _ IconicButton new borderWidth: 0;
			labelGraphic: (ScriptingSystem formAtKey: 'TinyMenu'); color: Color transparent; 
			actWhen: #buttonDown;
			actionSelector: #offerWindowMenu; target: self;
			setBalloonText: 'window menu')

"NB: for the moment, we always supply balloon help for this control, until people get used to it; eventually, we mays switch to showing this balloon help only in novice mode, as we do for the other standard window controls."