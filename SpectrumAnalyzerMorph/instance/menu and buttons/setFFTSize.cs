setFFTSize
	"Set the size of the FFT used for frequency analysis."

	| aMenu sz on |
	aMenu _ CustomMenu new title: 'FFT size (currently ', fft n printString, ')'.
	((7 to: 10) collect: [:n | 2 raisedTo: n]) do:[:r | aMenu add: r printString action: r].
	sz _ aMenu startUp.
	sz ifNil: [^ self].
	on _ soundInput isRecording.
	self stop.
	fft _ FFT new: sz.
	self resetDisplay.
	on ifTrue: [self start].
