translationsMenu: aMenu 
	^ aMenu add: 'remove (x)' translated action: #removeTranslation;
		 add: 'where (E)' translated action: #browseMethodsWithTranslation;
		 add: 'select all' translated action: #selectAllTranslation;
		 add: 'deselect all' translated action: #deselectAllTranslation;
		 add: 'select changed keys' translated action: #selectNewerKeys;
		 add: 'export selection' translated action: #codeSelectedTranslation;
		 add: 'export selection in do-it form' translated action: #codeSelectedTranslationAsMimeString;
		 add: 'reset changed keys' translated action: #resetNewerKeys;
		 yourself