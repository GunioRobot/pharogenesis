showResultDefects

	(self result failureCount > 0)
		ifTrue: [
			self errorLog cr; show: '---- SUnit ----- Failures ----'.
			self result failures do: [:failure |
				self errorLog crtab; show: failure printString]].
	(self result errorCount > 0)
		ifTrue: [
			self errorLog cr; show: '---- SUnit ------- Errors ----'.
			self result errors do: [:error |
				self errorLog crtab; show: error printString]].