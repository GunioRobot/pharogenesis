invokeMenu
	"Invoke the settings menu."

	| aMenu |
	aMenu _ CustomMenu new.
	aMenu addList:	{
		{'set sampling rate' translated.		#setSamplingRate}.
		{'set FFT size' translated.			#setFFTSize}.
		{'set display type' translated.		#setDisplayType}}.
	aMenu invokeOn: self defaultSelection: nil.
