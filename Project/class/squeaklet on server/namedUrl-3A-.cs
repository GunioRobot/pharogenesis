namedUrl: urlString
	| serverFile |
	"Return project if in, else nil"

	serverFile _ ServerFile new fullPath: urlString.
	^ Project named: (serverFile fileName findTokens: '|.') first

