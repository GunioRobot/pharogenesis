invokeMenu
	"Invoke a menu of additonal functions."

	| aMenu |
	aMenu := MenuMorph new.
	aMenu defaultTarget: self.

	aMenu addList:	{
		{'open file (o)' translated.			#openMPEGFile}.
		#-.
		{'rewind (r)' translated.				#rewindMovie}.
		{'play (p)' translated.				#startPlaying}.
		{'stop (s)' translated.				#stopPlaying}.
		{'previous frame (<-)' translated.	#previousFrame}.
		{'next frame (->)' translated.		#nextFrame}.
		#-.
	}.

	aMenu addLine.
	aMenu add: 'zoom' translated subMenu: self zoomSubMenu.
	aMenu add: 'subtitles' translated subMenu: self subtitlesSubMenu.
	aMenu add: 'advanced' translated subMenu: self advancedSubMenu.

	aMenu popUpEvent: self world activeHand lastEvent in: self world
