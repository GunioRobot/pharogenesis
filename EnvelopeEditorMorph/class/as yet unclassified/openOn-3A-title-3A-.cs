openOn: aSound title: aString
	"EnvelopeEditorMorph openOn: (AbstractSound soundNamed: 'brass1') copy
						title: 'test'"
	| m w |
	m _ self basicNew initOnSound: aSound title: aString.
	w _ WorldMorph new.
	w addMorph: m.
	MorphWorldView
		openOn: w
		label: aString
		extent: m fullBounds extent + 2.
