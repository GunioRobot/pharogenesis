openHelp
	| s |
	s _ self helpText, '
', self changesText.
	(Workspace new openLabel: 'Small help for Addressbook') contents: s;
		 contentsChanged