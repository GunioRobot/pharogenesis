currentExternalLocationInPercent
	"Warning this might not return what you want, it gets percentage based on audio, or video stream based on last usage, because we buffer audio it may give incorrect information when playing mpeg movies"
	^self external getPercentage