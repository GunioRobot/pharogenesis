lastSendersSearchSelector
	"Answer the last senders search selector, initializing it to a default value if it does not already have a value"

	^ currentQueryParameter ifNil: [currentQueryParameter _ #flag:]