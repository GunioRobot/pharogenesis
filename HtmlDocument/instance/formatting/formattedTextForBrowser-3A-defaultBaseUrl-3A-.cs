formattedTextForBrowser: browser  defaultBaseUrl: defaultBaseUrl
	"return a version of this document as a formatted Text (which includes links and such)"
	| formatter text |

	"set up the formatter"
	formatter _ HtmlFormatter preferredFormatterClass new.
	formatter browser: browser.
	formatter baseUrl: defaultBaseUrl.  "should check if the document specifies something else"

	"do the formatting"
	self addToFormatter: formatter.

	"get and return the result"
	text _ formatter text.
	^text