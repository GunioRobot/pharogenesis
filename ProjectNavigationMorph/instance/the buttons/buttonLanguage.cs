buttonLanguage
	"Answer a button for changing the language"
	| myButton m |
	myButton _ self makeButton: ''
		balloonText:  'Click here to choose your language.' translated
		for: #chooseLanguage.
	myButton addMorph: (m _ self languageIcon asMorph lock).
	myButton extent: m extent + (myButton borderWidth + 6).
	m position: myButton center - (m extent // 2).
	^ myButton