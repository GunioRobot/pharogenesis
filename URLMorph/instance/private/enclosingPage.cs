enclosingPage
	"Answer the inner-most SqueakPage contents that contains this morph, or nil if there isn't one."

	| m pg |
	m _ owner.
	[m == nil] whileFalse: [
		(m isKindOf: PasteUpMorph) ifTrue: [
			(pg _ SqueakPageCache pageForMorph: m) ifNotNil: [^ pg]].
		m _ m owner].
	^ nil
