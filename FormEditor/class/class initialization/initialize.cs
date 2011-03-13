initialize

	FlashCursor _ false.
	self setKeyboardMap.
	YellowButtonMenu _ PopUpMenu labels: 'accept
cancel
file out' lines: #(2).
	YellowButtonMessages _ #(accept cancel fileOut)

	"FormEditor initialize"