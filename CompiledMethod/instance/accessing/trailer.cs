trailer

	| end trailer |
	end _ self endPC.
	trailer _ ByteArray new: self size - end.
	end + 1 to: self size do: [:i | 
		trailer at: i - end put: (self at: i)].
	^ trailer