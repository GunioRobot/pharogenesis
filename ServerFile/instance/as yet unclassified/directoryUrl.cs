directoryUrl
	| ru |
	"A url to the directory this file is in"

	ru _ self realUrl.
	^ ru copyFrom: 1 to: (ru size - fileName size)