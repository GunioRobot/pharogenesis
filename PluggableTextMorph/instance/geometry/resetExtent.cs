resetExtent
	"Reset the extent while maintaining the current selection.  Needed when resizing while the editor is active (when inside the pane)."
	| tempSelection |
	textMorph notNil ifTrue:
		["the current selection gets munged by resetting the extent, so store it"
		tempSelection _ self selectionInterval.
		
		"don't reset it if it's not active"
		tempSelection = (Interval from: 1 to: 0) 
						ifTrue: [retractableScrollBar
							ifTrue:[ ^ self]].
		self extent: self extent.
		self setSelection: tempSelection]