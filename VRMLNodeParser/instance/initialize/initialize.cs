initialize
	| specs |
	specs _ self nodeSpecs.
	specs == nil ifTrue:[
		nodeTypes _ Dictionary new.
	] ifFalse:[
		nodeTypes _ Dictionary new: specs size.
		specs do:[:nodeSpec|
			nodeTypes at: nodeSpec name put: nodeSpec.
		].
	].