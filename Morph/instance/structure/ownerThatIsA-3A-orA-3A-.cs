ownerThatIsA: firstClass orA: secondClass
	"Return the first enclosing morph that is a kind of one of the two classes given, or nil if none"
	| current |
	current _ owner.
	[current == nil] whileFalse:
			[((current isKindOf: firstClass) or: [current isKindOf: secondClass]) ifTrue: [^ current].
			current _ current owner].
	^ current