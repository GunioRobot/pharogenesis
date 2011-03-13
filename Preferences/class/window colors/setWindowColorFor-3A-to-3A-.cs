setWindowColorFor: modelSymbol to: incomingColor
	| aColor aPrefSymbol aColorSpec |
	aColorSpec _ WindowColorRegistry registeredWindowColorSpecFor: modelSymbol.
	aColorSpec ifNil: [^self].
	aColor := incomingColor asNontranslucentColor.
	(aColor = ColorPickerMorph perniciousBorderColor or: [aColor = Color black]) 
		ifTrue: [^ self].	
	aPrefSymbol _ self windowColorPreferenceForClassNamed: aColorSpec classSymbol.
	self 
		addPreference: aPrefSymbol  
		categories:  { #'window colors' }
		default:  aColor 
		balloonHelp: aColorSpec helpMessage translated
		projectLocal: false
		changeInformee: nil
		changeSelector: nil
		viewRegistry: (PreferenceViewRegistry registryOf: #windowColorPreferences)