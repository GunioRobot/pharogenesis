writeColor: aColor
	self writeFloat: (aColor red roundTo: 0.001).
	self space.
	self writeFloat: (aColor green roundTo: 0.001).
	self space.
	self writeFloat: (aColor blue roundTo: 0.001).
