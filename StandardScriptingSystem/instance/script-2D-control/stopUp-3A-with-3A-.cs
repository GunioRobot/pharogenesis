stopUp: dummy with: theButton
	| aPresenter |
	(aPresenter _ theButton presenter) flushPlayerListCache.  "catch guys not in cache but who're running"
	aPresenter stopRunningScriptsFrom: theButton