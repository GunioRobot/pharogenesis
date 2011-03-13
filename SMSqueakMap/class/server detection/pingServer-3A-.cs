pingServer: aServerName
	"Check if the SqueakMap server is responding.
	For an old image we first make sure the name resolves -
	the #httpGet: had such a long timeout (and hanging?)
	for resolving the name."

	| url answer |
	"Only test name lookup first if image is before the network rewrite,
	after the rewrite it works."
	[(SystemVersion current highestUpdate < 5252)
		ifTrue: [NetNameResolver addressForName: (aServerName upTo: $:) timeout: 5].
	url := 'http://', aServerName, '/ping'.
	answer := HTTPSocket httpGet: url]
				on: Error do: [:ex | ^false].
	^answer isString not and: [answer contents = 'pong']