waitTimeoutSeconds: anInteger
	"Wait on this semaphore for up to the given number of seconds, then timeout. It is up to the sender to determine the difference between the expected event and a timeout."

	self waitTimeoutMSecs: anInteger * 1000.
