themeButton
	"Modified to make clear what the button actually does with respect to Polymorph."
	
	^themeButton ifNil: [
		themeButton := self basicButton 
			label: 'presets...' translated; 
			actionSelector: #themeSelected;
			setBalloonText: 
				'Numerous "Preferences" govern many things about the ',
				'way Squeak looks and behaves.  Set individual preferences ',
				'using a "Preferences" panel.  Set an entire group of many ',
				'Preferences all at the same time by pressing this "presets" ',
				'button and choosing a preset theme to install.  Look in ',
				'category "themes" in Preferences class to see what each ', 
				'theme does; add your own methods to the "themes" ',
				'category and they will show up in the list of theme choices.',
				String cr,
				'To change the appearance in a more fundamental way, ',
				'select a UI Theme in the "windows" category of this browser' translated].