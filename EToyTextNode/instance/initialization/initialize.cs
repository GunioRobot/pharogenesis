initialize

	| newStyle |
	super initialize.
	firstDisplay _ true.
	children _ OrderedCollection new.
	(newStyle _ TextStyle named: #Palatino) ifNotNil: [
		textStyle _ newStyle copy defaultFontIndex: 2
	].

