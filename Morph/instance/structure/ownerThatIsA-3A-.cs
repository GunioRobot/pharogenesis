ownerThatIsA: aClass
	"Return the first enclosing morph that is a kind of aClass, or nil if none"
	| current |
	current _ owner.
	[current == nil] whileFalse:
			[(current isKindOf: aClass) ifTrue: [^ current].
			current _ current owner].
	^ current