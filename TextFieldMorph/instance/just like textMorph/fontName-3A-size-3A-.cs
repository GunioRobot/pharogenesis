fontName: fontName size: fontSize
	| tm |
	"talk to my text"

	(tm _ self findA: TextMorph) ifNil: [^ nil].
	^ tm fontName: fontName size: fontSize
