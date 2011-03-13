userInitials: aString andPicture: aForm

	| qp cb pictRect initRect |

	userInitials _ aString.
	pictRect _ initRect _ cb _ self cursorBounds.
	userInitials isEmpty ifFalse: [
		qp _ DisplayScanner quickPrintOn: Display.
		initRect _ cb topRight + (0@4) extent: (qp stringWidth: userInitials)@(qp lineHeight).
	].
	self userPicture: aForm.
	aForm ifNotNil: [
		pictRect _ (self cursorBounds topRight + (0@24)) extent: aForm extent.
	].
	self bounds: ((cb merge: initRect) merge: pictRect).


