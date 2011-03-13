visibleAreas
	"Transcript dependents last controller visibleAreas"
	| visibleAreas rect remnants myTopController |
	myTopController := self view topView controller.
	visibleAreas := Array with: view insetDisplayBox.
	myTopController view uncacheBits.
	ScheduledControllers scheduledWindowControllers do:
		[:c | c == myTopController ifTrue: [^ visibleAreas].
		rect := c view windowBox.
		remnants := OrderedCollection new.
		visibleAreas do: [:a | remnants addAll: (a areasOutside: rect)].
		visibleAreas := remnants].
	^ visibleAreas