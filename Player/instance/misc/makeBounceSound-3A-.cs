makeBounceSound: soundName
	"Having bounced off an edge, produce the given sound"

	Preferences soundsEnabled
		ifTrue: [self costume playSoundNamed: soundName]