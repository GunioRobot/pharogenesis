relaunchAllViewers
	"Relaunch all the viewers in the project"

	| aViewer |
	(self submorphs select: [:m | m isKindOf: ViewerFlapTab]) do: 
			[:aTab | 
			aViewer := aTab referent submorphs 
						detect: [:sm | sm isStandardViewer]
						ifNone: [nil].
			aViewer ifNotNil: [aViewer relaunchViewer]
			"ActiveWorld relaunchAllViewers"]