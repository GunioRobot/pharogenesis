invokeMenu
	"Invoke the settings menu."

	| aMenu |
	aMenu _ CustomMenu new.
	aMenu addList:	#(
		('set sampling rate'		setSamplingRate)
		('set FFT size'			setFFTSize)
		('set display type'		setDisplayType)).
	aMenu invokeOn: self defaultSelection: nil.
