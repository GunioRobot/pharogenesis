zoomSubMenu
	"private - create the zoom submenu"

	| subMenu |

	subMenu := MenuMorph new.
	subMenu defaultTarget: self.

	self fullScreen
		ifTrue: [subMenu add: 'turn off full screen' translated action: #toggleFullScreen]
		ifFalse: [subMenu add: 'turn on full screen' translated action: #toggleFullScreen].

	subMenu addLine.
	subMenu add: '50%' action: #halfSize.
	subMenu add: '100%' action: #normalSize.
	subMenu add: '200%' action: #doubleSize.

	^ subMenu
