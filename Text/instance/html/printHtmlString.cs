printHtmlString
	"answer a string whose characters are the html representation 
	of the receiver"
	| html |
	html := String new writeStream.
	self printHtmlOn: html.
	^ html contents