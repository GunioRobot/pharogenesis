step

	| now mSecs mSecsPerFrame framesPerSec |
	framesSinceLastDisplay _ framesSinceLastDisplay + 1.
	now _ Time millisecondClockValue.
	mSecs _ now - lastDisplayTime.
	(mSecs > 500 or: [mSecs < 0 "clock wrap-around"]) ifTrue: [
		mSecsPerFrame _ mSecs // framesSinceLastDisplay.
		framesPerSec _ (framesSinceLastDisplay * 1000) // mSecs.
		self contents: mSecsPerFrame printString, ' mSecs (', framesPerSec printString, ' frames/sec)'.
		lastDisplayTime _ now.
		framesSinceLastDisplay _ 0]