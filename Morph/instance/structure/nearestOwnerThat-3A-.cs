nearestOwnerThat: aBlock
	"Return the first enclosing morph for which aBlock evaluates to true, or nil if none"
	| current |
	current _ owner.
	[current == nil] whileFalse:
			[(aBlock value: current) ifTrue: [^ current].
			current _ current owner].
	^ current