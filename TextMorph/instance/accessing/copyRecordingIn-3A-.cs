copyRecordingIn: dict
	"Overridden to copy deeper text structure."
	^ (super copyRecordingIn: dict)
		text: text copy textStyle: textStyle copy