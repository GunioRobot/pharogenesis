keyStroke: evt 
	| char asc |

	char := evt keyCharacter.
	asc := char asciiValue.
	(char = $o or:[ char = $O])
		ifTrue: 
			["open o/O" 
			self openMPEGFile. ^self].
	(char = $m or:[ char = $M])
		ifTrue: 
			["menu key m/M" 
			self invokeMenu. ^self].
	(char = $r or:[ char = $R])
		ifTrue: 
			["rewind r/R" 
			self rewindMovie. ^self].
	(char = $p or:[ char = $P])
		ifTrue: 
			["play p/P" 
			self startPlaying. ^self].
	(char = $s or:[ char = $S])
		ifTrue: 
			["stop s/S" 
			self stopPlaying. ^self].
	(asc = 28)
		ifTrue: 
			[ "left arrow key" 
			self previousFrame. ^self].
	(asc = 29)
		ifTrue: 
			[ "right arrow key" 
			self nextFrame. ^self].
	(char = $u or:[ char = $U])
		ifTrue: 
			["subtitles file u/U" 
			self openSubtitlesFile. ^self].