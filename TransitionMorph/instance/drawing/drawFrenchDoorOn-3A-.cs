drawFrenchDoorOn: aCanvas
	"startForm and endFrom are both fixed, but a border expands out from a vertical (or H) slit, revealing endForm.
	It's like opening a pair of doors."
	| box innerForm outerForm boxExtent h w |
	h _ self height. w _ self width.
	direction = #in ifTrue: [innerForm _ endForm.  outerForm _ startForm.
							boxExtent _ self stepFrom: 0@h to: self extent].
	direction = #out ifTrue: [innerForm _ startForm.  outerForm _ endForm.
							boxExtent _ self stepFrom: self extent to: 0@h].
	direction = #inH ifTrue: [innerForm _ endForm.  outerForm _ startForm.
							boxExtent _ self stepFrom: w@0 to: self extent].
	direction = #outH ifTrue: [innerForm _ startForm.  outerForm _ endForm.
							boxExtent _ self stepFrom: self extent to: w@0].
		
	aCanvas drawImage: outerForm at: self position.

	box _ Rectangle center: self center extent: boxExtent.
	aCanvas drawImage: innerForm at: box topLeft sourceRect: (box translateBy: self position negated).

	((box expandBy: 1) areasOutside: box) do:
		[:r | aCanvas fillRectangle: r color: Color black].
