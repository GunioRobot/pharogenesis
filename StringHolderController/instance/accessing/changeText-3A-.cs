changeText: aText
	"The paragraph to be edited is changed to aText."
	paragraph text: aText.
	self resetState.
	self selectInvisiblyFrom: paragraph text size + 1 to: paragraph text size.
	self selectAndScroll.
	self deselect