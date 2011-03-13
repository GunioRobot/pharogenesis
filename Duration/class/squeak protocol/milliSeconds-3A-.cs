milliSeconds: milliCount
	"Since seconds is 0 we can call the instance directly."

	^ self basicNew seconds: 0 nanoSeconds: milliCount * NanosInMillisecond