stepUp: evt with: aMorph
	(stepButton == nil or: [stepButton isInWorld not]) ifTrue: [stepButton _ aMorph].
	stepButton state: #off