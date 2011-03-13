drawSubmorphsOn: aCanvas 
	"Display submorphs back to front"

	|drawBlock i|
	submorphs isEmpty ifTrue: [^self].
	drawBlock := [:canvas |
		(self topVisibleRowForCanvas: aCanvas) to: (self bottomVisibleRowForCanvas: aCanvas) do: [ :row |
			i := self item: row.
			canvas fullDrawMorph: i]].
	self clipSubmorphs 
		ifTrue: [aCanvas clipBy: (aCanvas clipRect intersect: self clippingBounds) during: drawBlock]
		ifFalse: [drawBlock value: aCanvas]