readChunkTypeFrom: stream
	| s |
	s _ String new: 4.
	1 to: 4 do: [:i | s at: i put: (stream next) asCharacter].
	^ s
