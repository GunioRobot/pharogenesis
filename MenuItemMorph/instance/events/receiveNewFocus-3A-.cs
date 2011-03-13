receiveNewFocus: evt
	"Obsolete. Left in for not getting errors during the update where this entire stuff is removed."
	evt hand releaseKeyboardFocus.
	self flag: #arNote. "Remove it"