selectTab: aTab
	| aWorld |
	(aWorld _ self world) ifNotNil: [aWorld abandonAllHalos].  "nil can happen at init time"
	self highlightTab: aTab.
