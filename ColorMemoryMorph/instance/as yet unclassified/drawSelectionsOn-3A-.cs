drawSelectionsOn: aCanvas
	"highlight the borders of the colors we have used.  Current Color in black.  tk 6/29/97 15:29"

	| rect hilite |
	1 to: onVector size do: [:ind |
		(onVector at: ind) ifTrue: [
			rect _ self rectFromIndex: ind.
			aCanvas fillRectangle: rect color: Color black]].
	rect _ self rectFromIndex: current.
	hilite _ current = 5 "Red" 
		ifFalse: [Color red] ifTrue: [Color green].
	aCanvas fillRectangle: rect color: hilite.
