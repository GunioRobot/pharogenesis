jitterStartAndEndTimesBy: mSecs

	| r range halfRange oldEnd newEnd newStart |
	r _ Random new.
	range _ 2.0 * mSecs.
	halfRange _ mSecs.
	tracks do: [:t |
		t do: [:e |
			e isNoteEvent ifTrue: [
				oldEnd _ e time + e duration.
				newEnd _ oldEnd + ((r next * range) asInteger - halfRange).
				newStart _ e time + ((r next * range) asInteger - halfRange).
				e time: newStart.
				e duration: (newEnd - newStart)]]].

				