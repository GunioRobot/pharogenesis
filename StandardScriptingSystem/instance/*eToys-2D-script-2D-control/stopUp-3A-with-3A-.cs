stopUp: dummy with: theButton
	| aPresenter |
	(aPresenter := theButton presenter) flushPlayerListCache.  "catch guys not in cache but who're running"
	aPresenter stopRunningScriptsFrom: theButton