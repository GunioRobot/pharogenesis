highlightText: stringToHilite at: index in: insideOf
	"Find the container with this text and highlight it.  May not be able to do it for stringMorphs."

	"Find the container with that text"
	| container |
	self allMorphsDo: [:sub | 
		insideOf == sub userString ifTrue: [container _ sub]].
	container ifNil: [
		self allMorphsDo: [:sub | 
			insideOf = sub userString ifTrue: [container _ sub]]].	"any match"
	container ifNil: [^ nil].

	"Order it highlighted"
	(container isKindOf: TextMorph) ifTrue: [
		container editor selectFrom: index to: stringToHilite size - 1 + index].
	container changed.
	^ container
