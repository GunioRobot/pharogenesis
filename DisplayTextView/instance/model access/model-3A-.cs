model: aDisplayText 
	"Refer to the comment in View|model:."

	super model: aDisplayText.
	editParagraph _ model asParagraph.
	self centerText