highestSignificantFrequencyAt: startIndex
	"Answer the highest significant frequency in the sample window starting at the given index. The a frequency is considered significant if it's power is at least 1/50th that of the maximum frequency component in the frequency spectrum."

	| fft powerArray threshold indices |
	fft _ self fftAt: startIndex.
	powerArray _ self normalizedResultsFromFFT: fft.
	threshold _ powerArray max / 50.0.
	indices _ (1 to: powerArray size) select: [:i | (powerArray at: i) > threshold].
	^ originalSamplingRate / (fft samplesPerCycleForIndex: indices last)
