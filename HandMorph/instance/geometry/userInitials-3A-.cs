userInitials: aString

	| qp cb |
	userInitials _ aString.
	userInitials isEmpty ifFalse:
		[qp _ DisplayScanner quickPrintOn: Display.
		cb _ self cursorBounds.
		self bounds: (cb merge: (cb topRight + (0@4)
					extent: (qp stringWidth: userInitials)@(qp lineHeight)))]
