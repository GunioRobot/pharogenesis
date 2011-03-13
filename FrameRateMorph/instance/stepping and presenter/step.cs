step
	"Compute and display (every half second or so) the current framerate"

	| now mSecs mSecsPerFrame framesPerSec newContents |
	framesSinceLastDisplay _ framesSinceLastDisplay + 1.
	now _ Time millisecondClockValue.
	mSecs _ now - lastDisplayTime.
	(mSecs > 500 or: [mSecs < 0 "clock wrap-around"]) ifTrue: 
		[mSecsPerFrame _ mSecs // framesSinceLastDisplay.
		framesPerSec _ (framesSinceLastDisplay * 1000) // mSecs.
		newContents _ mSecsPerFrame printString, ' mSecs (', framesPerSec printString, ' frame', (framesPerSec == 1 ifTrue: [''] ifFalse: ['s']), '/sec)'.
		self contents: newContents.
		lastDisplayTime _ now.
		framesSinceLastDisplay _ 0]