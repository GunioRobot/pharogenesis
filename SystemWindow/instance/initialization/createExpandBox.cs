createExpandBox
	^ self createBox 
		
		labelGraphic: (ScriptingSystem formAtKey: 'expandBox');
	
		 extent: self boxExtent;
		 actWhen: #buttonUp;
		 actionSelector: #expandBoxHit;

		 setBalloonText: 'expand to full screen' translated