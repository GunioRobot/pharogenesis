addLowerLeftButtonsTo: aPasteUpMorph
	| aPosition cover aForm un m |
	super addLowerLeftButtonsTo: aPasteUpMorph.

	aPosition _ 4 @ (aPasteUpMorph height - 26).		"y of 454, parameterized"

	cover _ ThreePhaseButtonMorph new.
	cover image: (aForm _ ScriptingSystem formAtKey:  'BadgeMiniPic');
		offImage: aForm; pressedImage: aForm.
	cover target: self; actionSelector: #returnToFrontPage.
	cover setNameTo: 'Badge'; beSticky;
		setProperty: #scriptingControl toValue: true.
	cover align: cover bounds bottomLeft with: aPosition + (0@24).
	aPasteUpMorph addMorphBack: cover.
	cover beRepelling.

	un _ associatedMorph world userName.  "Rather special purpose here"
	un ifNil: [un _ 'Your Name Here'].
"	un _ (un = 'Your Name Here') | (un == nil) ifTrue: [''] ifFalse: [un]."
	m _ TextMorph new.		"User's name in mini badge"
	m string: un fontName: 'ComicBold' size: 16.
	cover addMorph: m.
	m extent: 120@26.
	m setProperty: #Transparent toValue: Color transparent.
	m align: m center with: cover center + (0@10); fit; centered