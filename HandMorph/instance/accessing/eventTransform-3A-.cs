eventTransform: aTransform
	"Note: This is ugly but there is no choice other than hacking the transform if you want to have continous scrolling during a #mouseStillDown: operation."
	eventTransform _ aTransform.