untranslatedMenu: aMenu 
	^ aMenu add: 'remove' translated action: #removeUntranslated;
		 add: 'translate (t)' translated action: #translate;
		 add: 'where (E)' translated action: #browseMethodsWithUntranslated;
		 yourself