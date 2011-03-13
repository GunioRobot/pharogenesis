default
	"InputEventFetcher default"

	^Default ifNil: [Default := InputEventPollingFetcher new]