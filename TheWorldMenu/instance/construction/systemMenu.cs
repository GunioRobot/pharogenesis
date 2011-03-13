systemMenu
	| menu |
	menu := MenuMorph new.
	self fillIn: menu from: {
		{'About...'. {SmalltalkImage current. #aboutThisSystem}}.
		{'Software update'. {Utilities. #updateFromServer}. 'load latest code updates via the internet'}.
		{'Preferences...'. {self. #appearanceDo}}}.
	^menu
	