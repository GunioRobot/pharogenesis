processKeyboard
	"Derived from a Martin Pammer submission, 02/98"

     | keyEvent oldSelection nextSelection max min howMany |
	sensor keyboardPressed ifFalse: [^ self].

     keyEvent := sensor keyboard asciiValue.
     oldSelection := view selection.
     nextSelection := oldSelection.
     max := view maximumSelection.
     min := view minimumSelection.
     howMany := view clippingBox height // view list lineGrid.

     keyEvent == 31 ifTrue:
		["down-arrow; move down one, wrapping to top if needed"
		nextSelection := oldSelection + 1.
		nextSelection > max ifTrue: [nextSelection _ 1]].

     keyEvent == 30 ifTrue:
		["up arrow; move up one, wrapping to bottom if needed"
		nextSelection := oldSelection - 1.
		nextSelection < 1 ifTrue: [nextSelection _ max]].

     keyEvent == 1  ifTrue: [nextSelection := 1].  "home"
     keyEvent == 4  ifTrue: [nextSelection := max].   "end"
     keyEvent == 11 ifTrue: [nextSelection := min max: (oldSelection -
howMany)].  "page up"
     keyEvent == 12  ifTrue: [nextSelection := (oldSelection + howMany)
min: max].  "page down"
     nextSelection = oldSelection  ifFalse:
		[model okToChange
			ifTrue:
				[self changeModelSelection: nextSelection.
				self moveMarker]]
			