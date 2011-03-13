pitchPoints: p
	pitchPoints := p isNumber
		ifTrue: [((0.0 to: duration by: 0.035) collect: [ :time | time @ p])]
		ifFalse: [p first isPoint ifTrue: [p] ifFalse: [(p collect: [ :each | each first @ each last])]]