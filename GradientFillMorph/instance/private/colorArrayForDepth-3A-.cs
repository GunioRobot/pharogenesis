colorArrayForDepth: d
	| range mix step |
	"We need to mix colors so as to minimize Mach bands (visible boundaries due to the fact that there is a sudden quantization change in one or more of the color components.  We use a 2x2 halftone as a simple solution.  On large areas, we only compute every fourth line for a factor of four in speed, and becuse it looks just as good.  The ideal way of doing this is by error propagation -- 1/2 the error to propagate back and forth across a word of pixels, and the other half to propagate down from one scan line to the next.  This will never be good enough with our 8-bit palette, and appears not to be needed in 16 bits."
	(colorArray == nil or: [colorDepth ~= d]) ifTrue:
		["ColorArray must be recomputed -- we cache the actual bitPatterns"
		colorDepth _ d.
		step _ self stepSize.
		colorArray _ Array new: (gradientDirection = #vertical
				ifTrue: [bounds height+(step-1)//step]
				ifFalse: [bounds width+(step-1)//step]).
		range _ (colorArray size - 1 max: 1) asFloat.
		1 to: colorArray size do:
			[:i | mix _ fillColor2 mixed: (i-1) / range with: color.
			colorArray at: i put: (mix balancedPatternForDepth: colorDepth)]].
	^ colorArray