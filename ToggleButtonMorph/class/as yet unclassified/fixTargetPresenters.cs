fixTargetPresenters
	"ToggleButtonMorph fixTargetPresenters"
	"Repair faulty instances from the first 'etoy-template' experiment, such that the instances refer to the local presenter rather than to a phantom and irrelevant world"
	self allSubInstancesDo:
		[:m | (m target isKindOf: Presenter) ifTrue:
			[m target: m presenter]]