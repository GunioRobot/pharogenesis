adjustWindowCorners 
	| box cornerBox p clicked f2 |
	box _ view windowBox.
	clicked _ false.
	#(topLeft topRight bottomRight bottomLeft)
		do: [:readCorner |
			cornerBox _ ((box insetBy: 2) perform: readCorner) - (10@10) extent: 20@20.
			(cornerBox containsPoint: sensor cursorPoint)
				ifTrue: 
				["Display reverse: cornerBox."
				(Cursor perform: readCorner) showWhile:
					[[(cornerBox containsPoint: (p _ sensor cursorPoint))
						and: [(clicked _ sensor anyButtonPressed) not]]
						whileTrue: [ self interActivityPause ].
				"Display reverse: cornerBox."
				clicked ifTrue:
					[view newFrame:
						[:f | p _ sensor cursorPoint.
						readCorner = #topLeft ifTrue:
							[f2 _ p corner: f bottomRight].
						readCorner = #bottomLeft ifTrue:
							[f2 _ (f withBottom: p y) withLeft: p x].
						readCorner = #bottomRight ifTrue:
							[f2 _ f topLeft corner: p].
						readCorner = #topRight ifTrue:
							[f2 _ (f withTop: p y) withRight: p x].
						f2]]]]].
	^ clicked