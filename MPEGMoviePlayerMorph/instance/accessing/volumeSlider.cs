volumeSlider
	"answer the receiver's volumeSlider  
	 
	note: if the instance var is undefined, try to get the sliders  
	from the allMorphs chain. in this way an instance of the  
	receiver created before the instVars was added can works fine"
	^ volumeSlider
		ifNil: [volumeSlider := self guessVolumeSlider]