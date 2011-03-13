model: aDisplayText 
	"Refer to the comment in View|model:."

	super model: aDisplayText.
	editParagraph := model asParagraph.
	self centerText