visibleAreas
	"Transcript dependents last controller visibleAreas"
	| visibleAreas rect remnants myTopController |
	myTopController _ self view topView controller.
	visibleAreas _ Array with: view insetDisplayBox.
	myTopController view uncacheBits.
	ScheduledControllers scheduledWindowControllers do:
		[:c | c == myTopController ifTrue: [^ visibleAreas].
		rect _ c view windowBox.
		remnants _ OrderedCollection new.
		visibleAreas do: [:a | remnants addAll: (a areasOutside: rect)].
		visibleAreas _ remnants].
	^ visibleAreas