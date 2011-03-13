createCloseBoxFor: aSystemWindow
	"Answer a button for closing the window."
	
	|form msb|
	form := self windowCloseForm.
	msb := MultistateButtonMorph new extent: form extent.
	msb activeEnabledNotOverUpFillStyle: (ImageFillStyle form: form).
	msb passiveEnabledNotOverUpFillStyle: (ImageFillStyle form: form).
	msb activeEnabledOverUpFillStyle: (ImageFillStyle form: form).
	msb passiveEnabledOverUpFillStyle: (ImageFillStyle form: form).
	
	form := self windowCloseDownForm.
	msb activeEnabledOverDownFillStyle: (ImageFillStyle form: form).
	msb passiveEnabledOverDownFillStyle: (ImageFillStyle form: form).
	msb addUpAction: [aSystemWindow closeBoxHit].
	msb setBalloonText: 'close' translated.
	"	extent: aSystemWindow boxExtent."
	^msb