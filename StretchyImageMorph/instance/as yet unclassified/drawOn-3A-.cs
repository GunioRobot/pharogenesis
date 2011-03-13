drawOn: aCanvas
| t |
"
Smalltalk at: #Q4 put: OrderedCollection new.
"
	form ifNil: [form _ (Form extent: 32@32 depth: 8) fillColor: Color green].
	(cache isNil or: [cache extent ~= bounds extent]) ifTrue: [
		t _ [cache _ Form extent: bounds extent depth: aCanvas depth.
		form displayInterpolatedIn: cache boundingBox on: cache] timeToRun.
		"Q4 add: {t. form. cache}."
	].
	aCanvas paintImage: cache at: bounds origin.
