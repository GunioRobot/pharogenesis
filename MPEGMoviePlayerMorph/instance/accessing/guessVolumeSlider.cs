guessVolumeSlider
	"private - look for a morph that is the receiver's volumeSlider"
	^ self allMorphs
		detect: [:each | "first look in my own morphs"
			each class == SimpleSliderMorph
				and: [each actionSelector == #volume:]]
		ifNone: [| w | 
			"second try, look all over the world (if any)"
			w := self world.
			w isNil
				ifFalse: [""
					w allMorphs
						detect: [:each | ""
							each class == SimpleSliderMorph
								and: [each actionSelector == #volume:]
								and: [each target == moviePlayer]]
						ifNone: []]]