useUpMemoryWithTinyObjects 
	"For testing the low space handler..."
	"Smalltalk installLowSpaceWatcher; useUpMemoryWithTinyObjects"

	| b |  "First use up most of memory."
	b _ String new: self bytesLeft - self lowSpaceThreshold - 100000.
	b _ b.  "Avoid unused value warning"
	(1 to: 10000) collect: [:i | BitBlt new]