basicFullDrawOn: aCanvas
	"Draw the full Morphic structure on the given Canvas.  This duplicates the implementation of fullDrawOn: (which could invoke this if it cared) but this method is never overridden, so that it can be invoked by subclass implementations of #fullDrawOn: without getting snagged by the complexities of intervening implementations of #fullDrawOn:"

	self visible ifFalse: [^ self].
	(self hasProperty: #errorOnDraw) ifTrue: [^ self drawErrorOn: aCanvas].
	aCanvas drawMorph: self.
	self drawSubmorphsOn: aCanvas
