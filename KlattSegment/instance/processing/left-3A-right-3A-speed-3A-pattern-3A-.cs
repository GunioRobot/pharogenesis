left: left right: right speed: speed pattern: patternFrame
	| frames leftSlope rightSlope value |
	frames _ (1 to: self duration * speed) collect: [ :each | patternFrame clone].
	self parameters do: [ :each |
		leftSlope _ self slopeWith: left selector: each selector speed: speed.
		rightSlope _ self slopeWith: right selector: each selector speed: speed.
		0 to: self duration * speed - 1 do: [ :time |
			value _ self interpolate: leftSlope with: rightSlope mid: each steady time: time speed: speed.
			(frames at: (time + 1) asInteger) perform: each selector with: value]].
	^ frames