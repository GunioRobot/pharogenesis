drawTabOn: aCanvas
	| top myColor cornerRadius myArcLengths myBounds |
	cornerRadius _ self cornerRadius.
	myBounds _ self bounds.
	self active
		ifTrue: [ top _ myBounds top.
			myColor _ self color ]
		ifFalse: [ top _ myBounds top + self topInactiveGap.
			myColor _ self color whiter whiter ].
	aCanvas fillRectangle:
		((myBounds left + cornerRadius)
				@ (top + cornerRadius)
			corner: (myBounds right - cornerRadius)
						@ self bottom)
		color: myColor.
	aCanvas fillRectangle:
		((myBounds left + (cornerRadius * 2)) @ top
			corner: (myBounds right - (cornerRadius * 2))
				@ (top + cornerRadius))
		color: myColor.
	aCanvas fillOval:
		((myBounds left + self cornerRadius) @ top
			corner: (myBounds left + (self cornerRadius * 3))
				@ (top + (self cornerRadius * 2)))
		color: myColor.
	aCanvas fillOval:
		((myBounds right - (self cornerRadius * 3)) @ top
			corner: (myBounds right - self cornerRadius)
				@ (top + (self cornerRadius * 2)))
		color: myColor.

	myArcLengths _ self arcLengths.
	1 to: myArcLengths size do: [ :i | | length |
		length _ myArcLengths at: i.
		aCanvas line: (myBounds left + cornerRadius - i) @ (myBounds bottom - 1 )
			to: (myBounds left + cornerRadius - i) @ (myBounds bottom - length - 1)
			color: myColor.
		aCanvas line: (myBounds right - cornerRadius + i - 1) @ (myBounds bottom - 1)
			to: (myBounds right - cornerRadius + i - 1) @ (myBounds bottom - length - 1)
			color: myColor]
	
