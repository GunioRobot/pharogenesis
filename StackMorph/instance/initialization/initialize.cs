initialize
	"Initialize the stack"

	| initialBackground |
	super initialize.
	initialBackground _ self findA: PasteUpMorph.  "yuk"
	initialBackground extent: (640@480); beSticky.
	initialBackground beAStackBackground.
	self beUnsticky.
	self setProperty: #controlsAtBottom toValue: true.

	cards _ OrderedCollection with: initialBackground currentDataInstance.

"self currentHand attachMorph: StackMorph authoringPrototype"