invokeMenu
	"Invoke a menu of additonal functions for this WaveEditor."

	| aMenu |
	aMenu _ CustomMenu new.
	aMenu addList:	#(
		('play straight through'		play)
		('play before cursor'		playBeforeCursor)
		('play after cursor'			playAfterCursor)
		('play test note'				playTestNote)
		('play loop'					playLoop)
		('trim before cursor'		trimBeforeCursor)
		('trim after cursor'			trimAfterCursor)
		('choose loop start'			chooseLoopStart)
		('jump to loop start'			jumpToLoopStart)
		('jump to loop end'			jumpToLoopEnd)
		('make unlooped'			setUnlooped)
		('make unpitched'			setUnpitched)
		('show envelope'			showEnvelope)
		('show FFT'					showFFTAtCursor)).
	aMenu invokeOn: self defaultSelection: nil.

