time: time startingF0: startingF0 amplitude: amplitude duration: duration peakPosition: peakPosition tilt: tilt
	| vowelStart riseAmplitude fallAmplitude |
	vowelStart := self timeOfFirstVowelAfter: time.
	riseAmplitude := tilt + 1.0 * amplitude / 2.0.
	fallAmplitude := amplitude - riseAmplitude.
	contour
		x: time y: startingF0;
		x: vowelStart + peakPosition y: ((startingF0 + riseAmplitude max: self lowPitch) min: self highPitch);
		x: time + duration y: ((startingF0 + riseAmplitude - fallAmplitude max: self lowPitch) min: self highPitch);
		commit