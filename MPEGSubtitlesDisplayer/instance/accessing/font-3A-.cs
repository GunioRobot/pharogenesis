font: aFont 
	"change the receiver's font"
	font := aFont.
	""
	self contents: ''.
	self contents: self contentsFromTarget