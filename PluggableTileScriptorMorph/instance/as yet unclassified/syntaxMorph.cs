syntaxMorph
	"Return the SyntaxMorph(MethodNode) that is inside me."

	| tm |
	^ (tm _ self findA: TransformMorph) ifNotNil: [tm findA: SyntaxMorph]