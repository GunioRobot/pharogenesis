prepend: stringOrText
	"add to my text"
	| tm |

	(tm _ self findA: TextMorph) ifNil: [^ nil].
	tm contents prepend: stringOrText.
	tm releaseParagraph; paragraph.


	