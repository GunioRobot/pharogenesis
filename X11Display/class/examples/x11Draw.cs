x11Draw
	"X11Display x11Draw"
	| display window gc nextPt lastPt ptr |
	display _ X11Display XOpenDisplay: nil.
	window _ display ourWindow.
	gc _ X11GC on: window.
	gc foreground: 0.
	lastPt _ nil.
	[ptr _ display queryPointer: window.	"{root. child. root pos. win pos. mask}"
	ptr last anyMask: 256] whileFalse:[
		nextPt _ ptr fourth.
		nextPt = lastPt ifFalse:[
			lastPt ifNotNil: [
				gc drawLineFrom: lastPt to: nextPt.
				display sync].
			lastPt _ nextPt].
	].
	gc free.
	display closeDisplay.
	Display forceToScreen.