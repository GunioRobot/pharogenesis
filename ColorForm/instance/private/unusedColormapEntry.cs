unusedColormapEntry
	"Return an unused color map entry."

	| tallies |
	tallies _ self tallyPixelValues.
	1 to: tallies size do: [:i |
		(tallies at: i) = 0 ifTrue: [^ i]].
