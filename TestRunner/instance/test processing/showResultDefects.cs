showResultDefects

	(self result failureCount > 0)
		ifTrue: [
			Transcript cr; show: '---- SUnit ----- Failures ----'.
			self result failures do: [:failure |
				Transcript crtab; show: failure printString]].
	(self result errorCount > 0)
		ifTrue: [
			Transcript cr; show: '---- SUnit ------- Errors ----'.
			self result errors do: [:error |
				Transcript crtab; show: error printString]].