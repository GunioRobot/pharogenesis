colorsUsed
	"Return a list of the colors acutally used by this ColorForm."

	| myColor list |
	myColor _ self colors.
	list _ OrderedCollection new.
	self tallyPixelValues doWithIndex: [:count :i |
		count > 0 ifTrue: [list add: (myColor at: i)]].
	^ list asArray
