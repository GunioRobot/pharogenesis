selectTab: aTab
	"In addition to setting the tab, if it's the actor viewer let that tab know that it's open"

	super selectTab: aTab.

	(aTab morphToInstall isKindOf: WonderlandActorViewer)
		ifTrue: [ myActorViewer turnUpdatingOn ]
		ifFalse: [ myActorViewer ifNotNil: [ myActorViewer turnUpdatingOff ] ].

