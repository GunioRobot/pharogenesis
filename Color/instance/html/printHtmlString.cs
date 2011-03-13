printHtmlString
	"answer a string whose characters are the html representation  
	of the receiver"
	^ (self red * 255) asInteger printStringHex , (self green * 255) asInteger printStringHex , (self blue * 255) asInteger printStringHex