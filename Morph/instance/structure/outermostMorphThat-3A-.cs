outermostMorphThat: aBlock
	"Return the outermost containing morph for which aBlock is true, or nil if none"
	| current outermost |
	current _ owner.
	[current == nil] whileFalse:
			[(aBlock value: current) ifTrue: [outermost _ current].
			current _ current owner].
	^ outermost