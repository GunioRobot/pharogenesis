deleteOldWindows
	" 
	FullImageTools new deleteOldWindows.
	"
	(SystemWindow
		windowsIn: World
		satisfying: [:each | #('Welcome to...' 'ReadMe.txt' 'A Word of Caution...' 'Welcome to...' ) includes: each label])
		do: [:each | 
			each isCollapsed
				ifTrue: [each expand].
			each submorphs second accept.
			each delete]