alpha: alphaValue
	"Return a new TransparentColor with the given amount of opacity ('alpha')."

	^ TranslucentColor basicNew setRgb: rgb alpha: alphaValue
