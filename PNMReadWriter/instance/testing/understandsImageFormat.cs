understandsImageFormat
	"P1 to P7"
	| p  |
	p _ stream next asCharacter.
	type _ stream next - 48.
	^(p = $P and:[type > 0 and:[type < 8]])
	