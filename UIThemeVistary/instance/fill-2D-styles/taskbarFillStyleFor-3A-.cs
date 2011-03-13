taskbarFillStyleFor: aTaskbar
	"Return the taskbar fillStyle for the given taskbar."
	
	|aColor c cm cd cb|
	aColor := aTaskbar color.
	c := aColor  alphaMixed: 0.1 with: Color white.
	cm := aColor alphaMixed: 0.8 with: Color white.
	cd := aColor alphaMixed: 0.6 with: Color black.
	cb := aColor alphaMixed: 0.7 with: Color white.
	^(GradientFillStyle ramp: {0.0->c. 0.49->cm. 0.5->cd. 1.0->cb})
		origin: aTaskbar position;
		direction: 0@27;
		radial: false
	