checkForReframe
	| box cornerBox clicked p |
	view isCollapsed ifTrue: [^ self].
	box _ view windowBox.
	#(topLeft topRight bottomRight bottomLeft)
		with: #(topLeft: topRight: bottomRight: bottomLeft:)
		do: [:readCorner :writeCorner |
			cornerBox _ (box perform: readCorner) - (8@8) extent: 16@16.
			(cornerBox containsPoint: (p _ sensor cursorPoint))
				& (box containsPoint: p) not
				ifTrue: 
				[clicked _ false.
				(Cursor perform: readCorner) showWhile:
					[[(cornerBox containsPoint: (p _ sensor cursorPoint))
						& (box containsPoint: p) not
						and: [(clicked _ sensor anyButtonPressed) not]]
						whileTrue.
				clicked ifTrue:
					[view newFrame:
						[:f | f copy perform: writeCorner with: sensor cursorPoint]]]]]