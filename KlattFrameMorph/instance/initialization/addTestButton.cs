addTestButton
	self addMorphBack: (SimpleButtonMorph new target: self; actWhen: #buttonDown; actionSelector:  #playTest; labelString: 'play')