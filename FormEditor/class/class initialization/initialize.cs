initialize

	FlashCursor := false.
	self setKeyboardMap.
	YellowButtonMenu := SelectionMenu 
		labels:
'accept
cancel
edit
file out'
		lines: #(2)
		selections: #(accept cancel edit fileOut).

	"FormEditor initialize"