userInitials: aString andPicture: aForm

	| cb pictRect initRect f |

	userInitials _ aString.
	pictRect _ initRect _ cb _ self cursorBounds.
	userInitials isEmpty ifFalse: [
		f _ TextStyle defaultFont.
		initRect _ cb topRight + (0@4) extent: (f widthOfString: userInitials)@(f height).
	].
	self userPicture: aForm.
	aForm ifNotNil: [
		pictRect _ (self cursorBounds topRight + (0@24)) extent: aForm extent.
	].
	self bounds: ((cb merge: initRect) merge: pictRect).


