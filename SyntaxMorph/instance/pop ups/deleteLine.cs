deleteLine
	| temp |
	temp _ owner.
	self deletePopup.
	self delete.
	temp setSelection: nil.
	temp acceptIfInScriptor.