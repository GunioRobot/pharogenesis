deletePackageWindows
	" 
	FullImageTools new deletePackageWindows.  
	"
	(SystemWindow
		windowsIn: World
		satisfying: [:each | #('README' 'CHANGES' 'Balloon3D tutorial' '3.7 Full Assembling') includes: each label])
		do: [:each | 
			each isCollapsed
				ifTrue: [each expand].
			each delete]