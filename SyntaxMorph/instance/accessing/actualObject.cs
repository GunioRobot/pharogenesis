actualObject
	| sub |
	"Who is self in these tiles?  Usually a Player."

	(self nodeClassIs: VariableNode) ifTrue: [
		(sub _ self findA: StringMorph) ifNil: [^ nil].
		^ References at: sub contents asSymbol ifAbsent: [nil]].

	(self nodeClassIs: LiteralNode) ifTrue: [
		(sub _ self findA: StringMorph) ifNil: [^ nil].
		^ Compiler evaluate: sub contents
				for: nil
				logged: false].

	(sub _ self findA: SyntaxMorph) ifNil: [^ nil].
	^ sub actualObject	"receiver"