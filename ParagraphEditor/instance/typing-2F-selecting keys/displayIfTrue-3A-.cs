displayIfTrue: characterStream 
	"Replace the current text selection with the text 'ifTrue:'--initiated by 
	ctrl-t."

	characterStream nextPutAll: 'ifTrue:'.
	^false