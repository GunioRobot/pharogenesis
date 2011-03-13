copyName
	"Copy the name of the current variable, so the user can paste it into the window below and work with is.  If collection, do (xxx at: 1). "

	| sel |
	sel _ '(self at: ', 
		(String streamContents: [:strm | (keyArray at: selectionIndex) storeOn: strm]) ,
		')'.
	Clipboard clipboardText: sel asText.	"no undo allowed"