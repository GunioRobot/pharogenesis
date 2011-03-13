accept 
	"Refer to the comment in ParagraphEditor|accept."

	super accept.
	model contents: paragraph string.
	self userHasNotEdited.
