addLabel: labelString atFrame: frame
	labels ifNil:[labels _ Dictionary new].
	labels at: labelString put: frame.