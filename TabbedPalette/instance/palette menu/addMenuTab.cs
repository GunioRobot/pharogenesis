addMenuTab
	| aMenu aTab aGraphic sk |
	aMenu _ MenuMorph new defaultTarget: self.
	aMenu stayUp: true.
	aMenu add:  'clear' action: #showNoPalette.
	aMenu add:  'sort tabs' action: #sortTabs:.
	aMenu add:  'choose new colors for tabs' action: #recolorTabs.
	aMenu setProperty: #paletteMenu toValue: true.
	aMenu add:  'make me the Standard palette' action: #becomeStandardPalette.
	aTab _ self addTabForBook: aMenu  withBalloonText: 'a menu of palette-related controls'.
	aTab highlightColor: tabsMorph highlightColor; regularColor: tabsMorph regularColor.
	tabsMorph laySubpartsOutInOneRow; layoutChanged.

	aGraphic _ ScriptingSystem formAtKey: 'Menu'.
	aGraphic ifNotNil:
		[aTab removeAllMorphs.
		aTab addMorph: (sk _ SketchMorph withForm: aGraphic).
		sk position: aTab position.
		sk lock.
		aTab fitContents].
	self layoutChanged