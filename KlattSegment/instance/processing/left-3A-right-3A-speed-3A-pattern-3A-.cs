left: left right: right speed: speed pattern: patternFrame
	| frames leftSlope rightSlope value |
	frames := (1 to: self duration * speed) collect: [ :each | patternFrame clone].
	self parameters do: [ :each |
		leftSlope := self slopeWith: left selector: each selector speed: speed.
		rightSlope := self slopeWith: right selector: each selector speed: speed.
		0 to: self duration * speed - 1 do: [ :time |
			value := self interpolate: leftSlope with: rightSlope mid: each steady time: time speed: speed.
			(frames at: (time + 1) asInteger) perform: each selector with: value]].
	^ frames