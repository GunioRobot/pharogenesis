createOrUpdateMainDockingBar
	"Private - create a new main docking bar or update the current one"
	| w mainDockingBars |
	w := self world.
	mainDockingBars := w mainDockingBars.
	mainDockingBars isEmpty
		ifTrue: ["no docking bar, just create a new one"
			TheWorldMainDockingBar instance createDockingBar openInWorld: w.
			^ self].
	""
	"update if nedeed"
	mainDockingBars
		do: [:each | TheWorldMainDockingBar instance updateIfNeeded: each]