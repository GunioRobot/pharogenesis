selectFrom: start to: stop
	"Deselect, then select the specified characters inclusive.
	 Be sure the selection is in view."

	self selectFrom: start to: stop scroll: #selectAndScroll