volumeForm: height from: start to: stop nSamplesPerPixel: nPerPixel
	"Note: nPerPixel can be Integer or Float for pixel-perfect alignment."
	"In an inspector of a samplesSound...
		self currentWorld addMorph: (ImageMorph new image:
			(self volumeForm: 32 from: 1 to: samples size nSamplesPerPixel: 225))
	"
	| volPlot width sample min max vol |
	width _ stop-start//nPerPixel.
	volPlot _ Form extent: width@height.
	(start max: 1) to: (stop min: samples size)-nPerPixel by: nPerPixel do:
		[:i | min_ max_ 0.
		i asInteger to: (i+nPerPixel-1) asInteger by: 4 do:  "by: 4 makes it faster yet looks the same"
			[:j | sample _ samples at: j.
			sample < min ifTrue: [min _ sample].
			sample > max ifTrue: [max _ sample]].
		vol _ (max - min) * height // 65536.
		volPlot fillBlack: ((i-start//nPerPixel) @ (height-vol//2) extent: 1@(vol+1))].
	^ volPlot
	
