getCursorPos
	| pt |
	pt _ self new.
	self apiGetCursorPos: pt.
	^pt