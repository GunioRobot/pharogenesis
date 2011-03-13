guessTypeFromName: url
	"guesses a content type from the url"
		^MIMEType forURIReturnSingleMimeTypeOrDefault: url asString asURI