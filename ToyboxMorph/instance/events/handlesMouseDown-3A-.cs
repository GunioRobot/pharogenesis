handlesMouseDown: evt
	"Grab mouse events either to drag an object out (if not locked) or to drag out a copy (if locked and copyWhenLocked)."

	(locked not or: [copyWhenLocked])
		ifTrue: [
			submorphs do: [:m |
				(m fullContainsPoint: evt cursorPoint) ifTrue: [^ true]]].
	^ false
