nextVisibleWindow
	"Answer the next (visible) window to navigate to."
	
	|sys|
	sys := self visibleSystemWindows.
	sys ifEmpty: [^nil].
	^sys after: self currentWindow ifAbsent: [sys first]