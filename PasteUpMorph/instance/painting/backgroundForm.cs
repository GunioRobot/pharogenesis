backgroundForm

	^ self backgroundSketch
		ifNil: [Form extent: self extent depth: Display depth]
		ifNotNil: [backgroundMorph form]