synthesizeFrame: aKlattFrame into: buffer startingAt: startIndex
	| noise voice frictionNoise aspirationNoise glotout
	parGlotout source temp out
	index top
	voicing parVoicing turbulence friction aspiration bypass
	gain ampGain |

	self returnTypeC: 'void'.
	self var: 'aKlattFrame' declareC: 'float *aKlattFrame'.
	self var: 'buffer' declareC: 'short *buffer'.
	self var: 'noise' declareC: 'float noise'.
	self var: 'voice' declareC: 'float voice'.
	self var: 'frictionNoise' declareC: 'float frictionNoise'.
	self var: 'aspirationNoise' declareC: 'float aspirationNoise'.
	self var: 'voicing' declareC: 'float voicing'.
	self var: 'parVoicing' declareC: 'float parVoicing'.
	self var: 'turbulence' declareC: 'float turbulence'.
	self var: 'friction' declareC: 'float friction'.
	self var: 'aspiration' declareC: 'float aspiration'.
	self var: 'bypass' declareC: 'float bypass'.
	self var: 'glotout' declareC: 'float glotout'.
	self var: 'parGlotout' declareC: 'float parGlotout'.
	self var: 'source' declareC: 'float source'.
	self var: 'gain' declareC: 'float gain'.
	self var: 'ampGain' declareC: 'float ampGain'.
	self var: 'out' declareC: 'float out'.

	self setCurrentFrame: aKlattFrame.

	pitch > 0
		ifTrue: [voicing _ self linearFromdB: (frame at: Voicing) - 7.
				parVoicing _ self linearFromdB: (frame at: Voicing).
				turbulence _ (self linearFromdB: (frame at: Turbulence)) * 0.1]
		ifFalse: [voicing _ parVoicing _ turbulence _ 0.0].

	friction _ (self linearFromdB: (frame at: Friction)) * 0.25.
	aspiration _ (self linearFromdB: (frame at: Aspiration)) * 0.05.
	bypass _ (self linearFromdB: (frame at: Bypass)) * 0.05.		"-26.0 dB"

	"Flod overall gain into output resonator (low-pass filter)"
	gain _ (frame at: Gain) - 3.
	gain <= 0 ifTrue: [gain _ 57].
	ampGain _ self linearFromdB: gain.
	self resonator: Rout frequency: 0 bandwidth: samplingRate gain: ampGain.

	noise _ nlast.
	index _ startIndex.
	top _ samplesPerFrame + startIndex - 1.
	[index <= top] whileTrue: [
		"Get low-passed random number for aspiration and friction noise"
		noise _ (self nextRandom - 32768) asFloat / 4.0. "radom number between -8196.0 and 8196.0"

		"Tilt down noise spectrum by soft low-pass filter having
		 a pole near the origin in the z-plane."
		noise _ noise + (0.75 * nlast).
		nlast _ noise.

		"Amplitude modulate noise (reduce noise amplitude during second
		 half of glottal period) if voicing  simultaneously present."
		nper > nmod ifTrue: [noise _ noise * 0.5].

		"Compute frictation noise"
		frictionNoise _ friction * noise.

		"Compute voicing waveform."
		voice _ self glottalSource.
		vlast _ voice.

		"Add turbulence during glottal open phase.
		 Use random rather than noise because noise is low-passed."
		nper < nopen ifTrue: [voice _ voice + (turbulence * (self nextRandom - 32768) asFloat / 4.0)].

		"Set amplitude of voicing."
		glotout _ voicing * voice.
		parGlotout _ parVoicing * voice.

		"Compute aspiration amplitude and add to voicing source."
		aspirationNoise _ aspiration * noise.
		glotout _ glotout + aspirationNoise.
		parGlotout _ parGlotout + aspirationNoise.

		"Cascade vocal tract, excited by laryngeal sources.
		 Nasal antiresonator, nasal resonator, trachearl antirresonator,
		 tracheal resonator, then formants F8, F7, F6, F5, F4, F3, F2, F1."
		out _ self cascadeBranch: glotout.

		"Voice-excited parallel vocal tract F1, F2, F3, F4, FNP and FTP."
		source _ parGlotout.	"Source is voicing plus aspiration."
		out _ out + (self parallelVoicedBranch: source).

		"Friction-excited parallel vocal tract formants F6, F5, F4, F3, F2,
		 outputs added with alternating sign. Sound source for other
		 parallel resonators is friction plus first difference of
		 voicing waveform."
		source _ frictionNoise + parGlotout - glast.
		glast _ parGlotout.
		out _ (self parallelFrictionBranch: source) - out.

		"Apply bypas and output low-pass filter"
		out _ bypass * source - out.
		out _ self resonator: Rout value: out.
		temp _ (out * ampGain) asInteger.
		temp < -32768 ifTrue: [temp _ -32768].
		temp > 32767 ifTrue: [temp _ 32767].
		buffer at: index - 1 put: temp.
		index _ index + 1.
		samplesCount _ samplesCount + 1]