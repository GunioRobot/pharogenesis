computeMorphWidths
	| paneWidths widths |
	paneWidths _ self paneWidthsToFit: self totalPaneWidth.
	widths _ OrderedCollection new.
	paneWidths do: [:w | widths add: w] separatedBy: [widths add: self separatorWidth].
	^ widths asArray
