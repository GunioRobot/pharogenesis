addLabel: labelString atFrame: frame
	labels ifNil:[labels := Dictionary new].
	labels at: labelString put: frame.