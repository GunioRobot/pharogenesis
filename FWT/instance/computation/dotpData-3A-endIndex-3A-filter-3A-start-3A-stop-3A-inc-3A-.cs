dotpData: data endIndex: endIndex filter: filter start: start stop: stop inc: inc
	| sum i j |
	sum _ 0.0.
	j _ endIndex.
	i _ start.
	[i <= stop] whileTrue:
		[sum _ sum + ((data at: j) * (filter at: i)).
		i _ i + inc.
		j _ j - 1].
	^ sum