createMenuBox
	^ self createBox 
		
		labelGraphic: (ScriptingSystem formAtKey: 'TinyMenu');

		 extent: self boxExtent;
		 actWhen: #buttonDown;
		 actionSelector: #offerWindowMenu;
		 setBalloonText: 'window menu' translated