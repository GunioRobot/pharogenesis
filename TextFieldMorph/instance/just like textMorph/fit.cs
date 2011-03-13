fit
	"tell my text to recompute its looks"
	| tm |

	(tm _ self findA: TextMorph) ifNil: [^ nil].
	tm releaseParagraph; paragraph.