initializePreferences
	
	(Preferences preferenceAt: #syntaxHighlightingAsYouType) ifNil:[
		Preferences 
			disable: #colorWhenPrettyPrinting;
			disable: #browseWithPrettyPrint.
		Preferences 
			addPreference: #syntaxHighlightingAsYouType
			 categories: #( browsing)
			default: true 
			balloonHelp: 'Enable, or disable, Shout - Syntax Highlighting As You Type. When enabled, code in Browsers and Workspaces is styled to reveal its syntactic structure. When the code is changed (by typing some characters, for example), the styling is changed so that it remains in sync with the modified code'].
	(Preferences preferenceAt: #syntaxHighlightingAsYouTypeAnsiAssignment) ifNil:[
		Preferences 
			addPreference: #syntaxHighlightingAsYouTypeAnsiAssignment
			 categories: #( browsing)
			default: (Preferences ansiAssignmentOperatorWhenPrettyPrinting) 
			balloonHelp: 'If true, and syntaxHighlightingAsYouType is enabled,  all left arrow assignments ( _ ) will be converted to the ANSI format ( := ) when a method is selected in a Browser. Whilst editing a method, this setting has no effect - both the left arrow and the ansi format may be used'.
		(Preferences preferenceAt: #syntaxHighlightingAsYouTypeAnsiAssignment)
			changeInformee: self
			changeSelector: #ansiAssignmentPreferenceChanged].		
	(Preferences preferenceAt: #syntaxHighlightingAsYouTypeLeftArrowAssignment) ifNil:[
		Preferences 
			addPreference: #syntaxHighlightingAsYouTypeLeftArrowAssignment
		 	categories: #( browsing)
			default: (Preferences ansiAssignmentOperatorWhenPrettyPrinting not) 
			balloonHelp: 'If true, and syntaxHighlightingAsYouType is enabled,  all ANSI format assignments ( := ) will be converted to left arrows ( _ ) when a method is selected in a Browser. Whilst editing a method, this setting has no effect - both the left arrow and the ansi format may be used'.
		(Preferences preferenceAt: #syntaxHighlightingAsYouTypeLeftArrowAssignment)
			changeInformee: self 
			changeSelector: #leftArrowAssignmentPreferenceChanged ].							