fill: evt
	"Find the area that is the same color as where you clicked.  Fill it with the current paint color."

evt isMouseUp ifTrue: ["Only fill upon mouseUp"
	Cursor execute showWhile:
		[paintingForm shapeFill: self currentColor interiorPoint: evt cursorPoint - bounds origin.
		self render: bounds.	"would like to only invalidate the area 
				changed, but can't find out what it is."
		]].
