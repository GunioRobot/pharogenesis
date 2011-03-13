displayIfFalse: characterStream 
	"Replace the current text selection with the text 'ifFalse:'--initiated by 
	ctrl-f."

	characterStream nextPutAll: 'ifFalse:'.
	^false