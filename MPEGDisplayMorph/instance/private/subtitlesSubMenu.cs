subtitlesSubMenu
	"private - create the subtitles submenu"

	| subMenu |

	subMenu := MenuMorph new.
	subMenu defaultTarget: self.
	subMenu add: 'open subtitles file (u)' translated action: #openSubtitlesFile.

	self hasSubtitles
		ifTrue: [
			subMenu addLine.
			subMenu add: 'set subtitles font' translated action: #setSubtitlesFont.
			subMenu add: 'set subtitles color' translated action: #setSubtitlesColor.
			subMenu add: 'set subtitles background color' translated action: #setSubtitlesBackgroundColor].

	^ subMenu
