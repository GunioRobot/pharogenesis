addEnvelopeNamed: envName
	| points env |
	points _ OrderedCollection new.
	points add: 0@0.0;
		add: (envelope points at: envelope loopStartIndex) x@1.0;
		add: (envelope points at: envelope loopEndIndex) x@1.0;
		add: (envelope points last) x@0.0.
	envName = 'volume' ifTrue:
		[env _ VolumeEnvelope points: points loopStart: 2 loopEnd: 3.
		env target: sound; scale: 0.7].
	envName = 'modulation' ifTrue:
		[env _ Envelope points: (points collect: [:p | p x @ 0.5])
						loopStart: 2 loopEnd: 3.
		env target: sound; updateSelector: #modulation:;
			scale: sound modulation*2.0].
	envName = 'pitch' ifTrue:
		[env _ PitchEnvelope points: (points collect: [:p | p x @ 0.5])
						loopStart: 2 loopEnd: 3.
		env target: sound; updateSelector: #pitch:; scale: 0.5].
	envName = 'random pitch:' ifTrue:
		[env _ RandomEnvelope for: #pitch:.
		points _ OrderedCollection new.
		points add: 0@(env delta * 5 + 0.5);
			add: (envelope points at: envelope loopStartIndex) x@(env highLimit - 1 * 5 + 0.5);
			add: (envelope points at: envelope loopEndIndex) x@(env highLimit - 1 * 5 + 0.5);
			add: (envelope points last) x@(env lowLimit - 1 * 5 + 0.5).
		env setPoints: points loopStart: 2 loopEnd: 3.
		env target: sound. ].
	envName = 'ratio' ifTrue:
		[denominator _ 9999.  "No gridding"
		env _ Envelope points: (points collect: [:p | p x @ 0.5])
						loopStart: 2 loopEnd: 3.
		env target: sound; updateSelector: #ratio:;
			scale: sound ratio*2.0].
	env ifNotNil:
		[sound addEnvelope: env.
		self editEnvelope: env]