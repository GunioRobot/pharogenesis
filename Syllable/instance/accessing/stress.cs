stress
	self phonemes do: [ :each | each stress > 0 ifTrue: [^ each stress]].
	^ 0