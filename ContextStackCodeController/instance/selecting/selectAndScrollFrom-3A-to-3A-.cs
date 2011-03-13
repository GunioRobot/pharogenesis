selectAndScrollFrom: start to: stop

	"Select the characters from character position start to position stop. Then 
	move the window so that this selection is visible."

	self deselect.
	startBlock _ paragraph characterBlockForIndex: start.
	stopBlock _ paragraph characterBlockForIndex: stop + 1.
	self selectAndScroll