accept
	"Save the current text of the text being edited as the current acceptable version for purposes of canceling.  
	7/16/96 sw: call view.accepted, giving the view a chance to take special action at this juncture."

	initialText _ paragraph text copy.
	view accepted