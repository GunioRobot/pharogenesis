setCurrentFrame: aKlattFrame
	| ampFNV ampFTV ampF1V ampF2V ampF3V ampF4V ampF2F ampF3F ampF4F ampF5F ampF6F |
	self returnTypeC: 'void'.
	self var: 'aKlattFrame' declareC: 'float *aKlattFrame'.
	self var: 'ampFNV' declareC: 'float ampFNV'.
	self var: 'ampFTV' declareC: 'float ampFTV'.
	self var: 'ampF1V' declareC: 'float ampF1V'.
	self var: 'ampF2V' declareC: 'float ampF2V'.
	self var: 'ampF3V' declareC: 'float ampF3V'.
	self var: 'ampF4V' declareC: 'float ampF4V'.
	self var: 'ampF2F' declareC: 'float ampF2F'.
	self var: 'ampF3F' declareC: 'float ampF3F'.
	self var: 'ampF4F' declareC: 'float ampF4F'.
	self var: 'ampF5F' declareC: 'float ampF5F'.
	self var: 'ampF6F' declareC: 'float ampF6F'.

	frame _ aKlattFrame.

	"Fudge factors..."
	ampFNV _ (self linearFromdB: (frame at: Anv)) * 0.6.	"-4.44 dB"
	ampFTV _ (self linearFromdB: (frame at: Atv)) * 0.6.		"-4.44 dB"
	ampF1V _ (self linearFromdB: (frame at: A1v)) * 0.4.		"-7.96 dB"
	ampF2V _ (self linearFromdB: (frame at: A2v)) * 0.15.	"-16.5 dB"
	ampF3V _ (self linearFromdB: (frame at: A3v)) * 0.06.	"-24.4 dB"
	ampF4V _ (self linearFromdB: (frame at: A4v)) * 0.04.	"-28.0 dB"
	ampF2F _ (self linearFromdB: (frame at: A2f)) * 0.15.		"-16.5 dB"
	ampF3F _ (self linearFromdB: (frame at: A3f)) * 0.06.	"-24.4 dB"
	ampF4F _ (self linearFromdB: (frame at: A4f)) * 0.04.	"-28.0 dB"
	ampF5F _ (self linearFromdB: (frame at: A5f)) * 0.022.	"-33.2 dB"
	ampF6F _ (self linearFromdB: (frame at: A6f)) * 0.03.	"-30.5 dB"

	"Set coefficients of variable cascade resonators"
	cascade >= 8
		ifTrue: [samplingRate >= 16000	"Inside Nyquist rate?"
					ifTrue: [self resonator: R8c frequency: 7500 bandwidth: 600]
					ifFalse: [cascade _ 6]].
	cascade >= 7
		ifTrue: [samplingRate >= 16000	"Inside Nyquist rate?"
					ifTrue: [self resonator: R7c frequency: 6500 bandwidth: 500]
					ifFalse: [cascade _ 6]].
	cascade >= 6 ifTrue: [self resonator: R6c frequency: (frame at: F6) bandwidth: (frame at: B6)].
	cascade >= 5 ifTrue: [self resonator: R5c frequency: (frame at: F5) bandwidth: (frame at: B5)].
	self resonator: R4c frequency: (frame at: F4) bandwidth: (frame at: B4).
	self resonator: R3c frequency: (frame at: F3) bandwidth: (frame at: B3).
	self resonator: R2c frequency: (frame at: F2) bandwidth: (frame at: B2).
	self resonator: R1c frequency: (frame at: F1) bandwidth: (frame at: B1).

	"Set coefficients of nasal and tracheal resonators and antiresonators"
	self resonator: Rnpc frequency: (frame at: Fnp) bandwidth: (frame at: Bnp).
	self resonator: Rtpc frequency: (frame at: Ftp) bandwidth: (frame at: Btp).
	self antiResonator: Rnz frequency: (frame at: Fnz) bandwidth: (frame at: Bnz).
	self antiResonator: Rtz frequency: (frame at: Ftz) bandwidth: (frame at: Btz).

	"Set coefficients of parallel resonators, and amplitude of outputs"
	self resonator: Rnpp frequency: (frame at: Fnp) bandwidth: (frame at: Bnp) gain: ampFNV.
	self resonator: Rtpp frequency: (frame at: Ftp) bandwidth: (frame at: Btp) gain: ampFTV.
	self resonator: R1vp frequency: (frame at: F1) bandwidth: (frame at: B1) gain: ampF1V.
	self resonator: R2vp frequency: (frame at: F2) bandwidth: (frame at: B2) gain: ampF2V.
	self resonator: R3vp frequency: (frame at: F3) bandwidth: (frame at: B3) gain: ampF3V.
	self resonator: R4vp frequency: (frame at: F4) bandwidth: (frame at: B4) gain: ampF4V.
	self resonator: R2fp frequency: (frame at: F2) bandwidth: (frame at: B2f) gain: ampF2F.
	self resonator: R3fp frequency: (frame at: F3) bandwidth: (frame at: B3f) gain: ampF3F.
	self resonator: R4fp frequency: (frame at: F4) bandwidth: (frame at: B4f) gain: ampF4F.
	self resonator: R5fp frequency: (frame at: F5) bandwidth: (frame at: B5f) gain: ampF5F.
	self resonator: R6fp frequency: (frame at: F6) bandwidth: (frame at: B6f) gain: ampF6F