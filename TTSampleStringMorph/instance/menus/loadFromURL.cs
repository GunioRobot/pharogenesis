loadFromURL
	"Allow the user to change the text in a crude way"

	| url |
	url := UIManager default request:  ' Type in the url for a TrueType font on the web.' translated
				 initialAnswer: 'http://www.fontguy.com/download.asp?fontid=1494'.
	url isEmptyOrNil ifTrue: [^ self].
	self loadFromURL: url.
