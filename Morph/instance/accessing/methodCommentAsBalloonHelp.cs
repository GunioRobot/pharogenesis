methodCommentAsBalloonHelp
	"Given that I am a morph that is associated with an object and a method, answer a suitable method comment relating to that object & method if possible"

	| inherentSelector actual |
	(inherentSelector _ self valueOfProperty: #inherentSelector)
		ifNotNil:
			[(actual _ (self ownerThatIsA: PhraseTileMorph orA: SyntaxMorph) actualObject) ifNotNil:
				[^ actual class precodeCommentOrInheritedCommentFor: inherentSelector]].
	^ nil