initialize: primaryFlag mpegPlayer: aMpegPlayerOrFileName 
	| rect sizeToOverLapBoundary |
	primary := primaryFlag.
	rect := self bounds.
	sizeToOverLapBoundary := 3.0.
	mpegLogic := primary 
				ifTrue:  
					[form := Form 
								extent: ((sizeToOverLapBoundary * rect width) 
										@ (sizeToOverLapBoundary * rect height)) truncated
								depth: 32.
					movieDrawArea := SketchMorph withForm: form.
					MPEGPlayer playFile: aMpegPlayerOrFileName onMorph: movieDrawArea]
				ifFalse: 
					[form := aMpegPlayerOrFileName form.
					movieDrawArea := aMpegPlayerOrFileName movieDrawArea.
					aMpegPlayerOrFileName mpegLogic]