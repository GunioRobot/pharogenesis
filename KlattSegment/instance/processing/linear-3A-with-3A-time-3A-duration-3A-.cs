linear: a with: b time: time duration: dur
	time <= 0 ifTrue: [^ a].
	time >= dur ifTrue: [^ b].
	^ b - a * time / dur + a