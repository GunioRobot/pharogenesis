initialize

	FlashCursor _ false.
	self setKeyboardMap.
	YellowButtonMenu _ SelectionMenu 
		labels:
'accept
cancel
edit
file out'
		lines: #(2)
		selections: #(accept cancel edit fileOut).

	"FormEditor initialize"