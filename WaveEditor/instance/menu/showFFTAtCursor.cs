showFFTAtCursor

	| data start availableSamples nu n fft r |
	data _ graph data.
	start _ graph cursor max: 1.
	availableSamples _ (data size - start) + 1.
	nu _ 12.
	nu > (availableSamples highBit - 1) ifTrue:
		[^ self inform: 'Too few samples after the cursor to take an FFT.' translated].
	n _ 2 raisedTo: nu.
	fft _ FFT new nu: nu.
	fft realData: ((start to: start + n - 1) collect: [:i | data at: i]).
	fft transformForward: true.
	r _ (1 to: n // 2) collect:
		[:i | ((fft realData at: i) squared + (fft imagData at: i) squared) sqrt].
	WaveEditor openOn: r.

