mouseEnter: evt

	evt hand newKeyboardFocus: self.
	currentKeyDown _ Set new.
	hasFocus _ true.

