initialize

	FlashCursor _ false.
	self setKeyboardMap.
	YellowButtonMenu _ PopUpMenu labels: 'accept
cancel
edit
file out' lines: #(2).
	YellowButtonMessages _ #(accept cancel edit fileOut)

	"FormEditor initialize"