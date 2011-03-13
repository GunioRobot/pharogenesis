playEvent: event frames: frames at: time
	| frame breathyAspiration formantScale |
	breathyAspiration := self dBFromLinear: (self linearFromdB: 68) * self breathiness.
	formantScale := self formantScale.
	1 to: frames size do: [ :each |
		frame := frames at: each.
		frame gain: (self dBFromLinear: (self linearFromdB: frame gain) * event loudness).
		frame f0: (event pitchAt: each - 1 * event duration / frames size).
		frame voicing: (self dBFromLinear: (self linearFromdB: frame voicing) * (1.0 - self breathiness)).
		frame aspiration: (frame aspiration max: breathyAspiration).
		frame
			f1: frame f1 * formantScale;
			f2: frame f2 * formantScale;
			f3: frame f3 * formantScale;
			f4: frame f4 * formantScale;
			f5: frame f5 * formantScale;
			f6: frame f6 * formantScale].
	"Transcript cr; show: (event duration * 1000 / frames size) printString."
	synthesizer millisecondsPerFrame: event duration * 1000 / frames size.
	self playBuffer: (synthesizer samplesFromFrames: frames) at: time