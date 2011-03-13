usePangoRenderer

	| tr font phraseTest fontName |
	Preferences usePangoRenderer ifTrue: [^ true].

	"first, see if people specified font." 
	tr := NaturalLanguageTranslator current.
	fontName := tr translate: 'Linux-Font'.
	(fontName ~= 'Linux-Font'
			and: [(StrikeFont familyNames includes: fontName asSymbol) not]) ifTrue: [^ true].

	font := TextStyle defaultFont.
	phraseTest := [:phrase |
		phrase  do: [:c |
			(font hasGlyphWithFallbackOf: c) ifFalse: [^ true]]].

	"Hopefully people start translating phrases that are really used, but also people translate on the Pootle server which has a ideosyncratic ordering..."
	#('Rectangle' 'Text' 'forward by' 'turn by' 'color' 'choose new graphic' 'linear gradient' 'open as Flash' 'set custom action' 'show compressed size' 'more smoothing') do: [:ph | phraseTest value: (tr translate: ph)].

	"But it is not often the case; so a bit more testing..."
	10 timesRepeat: [
		phraseTest value: tr atRandom].

	^ false.
