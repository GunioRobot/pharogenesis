trimmedThreshold: threshold

	| start end |
	start _ self indexOfFirstSampleOver: threshold.
	end _  self indexOfLastSampleOver: threshold.
	start > end ifTrue: [^ SoundBuffer new].
	start _ (start - 200) max: 1.
	end _ (end + 200) min: self size.
	^ self copyFrom: start to: end
