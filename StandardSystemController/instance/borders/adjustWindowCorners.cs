adjustWindowCorners 
	| box cornerBox p clicked f2 |
	box := view windowBox.
	clicked := false.
	#(topLeft topRight bottomRight bottomLeft)
		do: [:readCorner |
			cornerBox := ((box insetBy: 2) perform: readCorner) - (10@10) extent: 20@20.
			(cornerBox containsPoint: sensor cursorPoint)
				ifTrue: 
				["Display reverse: cornerBox."
				(Cursor perform: readCorner) showWhile:
					[[(cornerBox containsPoint: (p := sensor cursorPoint))
						and: [(clicked := sensor anyButtonPressed) not]]
						whileTrue: [ self interActivityPause ].
				"Display reverse: cornerBox."
				clicked ifTrue:
					[view newFrame:
						[:f | p := sensor cursorPoint.
						readCorner = #topLeft ifTrue:
							[f2 := p corner: f bottomRight].
						readCorner = #bottomLeft ifTrue:
							[f2 := (f withBottom: p y) withLeft: p x].
						readCorner = #bottomRight ifTrue:
							[f2 := f topLeft corner: p].
						readCorner = #topRight ifTrue:
							[f2 := (f withTop: p y) withRight: p x].
						f2]]]]].
	^ clicked