cosine: a with: b time: time duration: dur
	time <= 0 ifTrue: [^ a].
	time >= dur ifTrue: [^ b].
	^ ((time / dur * Float pi) cos - 1 / -2.0) * (b - a) + a