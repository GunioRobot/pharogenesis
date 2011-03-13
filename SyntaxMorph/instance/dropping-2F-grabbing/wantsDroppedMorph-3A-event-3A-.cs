wantsDroppedMorph: aMorph event: evt
	"For the moment, you have to drop it the right place.  We do not look at enclosing morphs"
	"Two ways to do this:  Must always destroy old node, then drag in new one.
		Or, drop replaces what you drop on.  Nasty with blocks."

	| meNoun itNoun |
	(aMorph isKindOf: SyntaxMorph) ifFalse: [^ false].

	"If nodes are of equal class, replace me with new one."
	(self nodeClassIs: MessageNode) ifFalse: [
		(self nodeClassIs: aMorph parseNode class) ifTrue: [^ true]].

	meNoun _ self isNoun.
	itNoun _ aMorph isNoun.

	"Consider these nouns to be equal:  TempVariableNode, LiteralNode, VariableNode, (MessageNode with receiver), CascadeNode, AssignmentNode"
	meNoun & itNoun ifTrue: [^ true].
	meNoun & aMorph isBlockNode ifTrue: [^ true].

	"If I am a BlockNode, and it is a TempVariableNode, add it into list"
	"If I am a BlockNode, and it is a noun, add it as a new line"
	self isBlockNode ifTrue:
		[itNoun ifTrue: [^ true].
		(aMorph nodeClassIs: ReturnNode) ifTrue:
			[^ (self submorphs
				detect: [:mm | ((mm isSyntaxMorph) and: [mm nodeClassIs: ReturnNode])]
				ifNone: [nil]) isNil]].	"none already in this block"
				"If I am a BlockNode, and it is a ReturnNode, add to end"

	(self isMethodNode) ifTrue: [^ false].	"Later add args and keywords"
		"Later allow comments to be dropped in"
		"Add MethodTemps by dropping into the main block"

	^ false "otherwise reject"
