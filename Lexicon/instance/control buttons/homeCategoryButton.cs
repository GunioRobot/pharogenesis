homeCategoryButton
	"Answer a button that brings up a menu.  Useful when adding new features, but at present is between uses"

	^ IconicButton new target: self;
		borderWidth: 0;
		labelGraphic: (ScriptingSystem formAtKey: #Cat);
		color: Color transparent; 
		actWhen: #buttonUp;
		actionSelector: #showHomeCategory;
		setBalloonText: 'show this method''s home category';
		yourself