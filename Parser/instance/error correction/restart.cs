restart
	"This SHOULD restart compilation, but since the parser
	doesnt have access to the corrected text, we have to ask 
	the user to restart.  Sigh."
	PopUpMenu notify: 'I was able to make the correction,
but I need you to re-accept -- thanks'.
	self fail